using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine.Strategy;
using UniTaskSTM.Node;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ZaCo.Core;
using StateMachine.Node;

namespace UniTaskSTM.StateMachine
{
    public class UniTaskStateMachine : IStateMachineStrategy
    {
        #region  YieldAwaiter
        
        public struct YieldAwaitable
        {
            //https://qiita.com/tatsunoru/items/ec113ac9381032533268        
            public struct YieldAwaiter : System.Runtime.CompilerServices.ICriticalNotifyCompletion
            {
                CancellationToken token;
                PlayerLoopTiming timing;

                public YieldAwaiter(PlayerLoopTiming timing, CancellationToken token)
                {
                    this.token = token;
                    this.timing = timing;
                }

                public bool IsCompleted => false;

                public void GetResult() => token.ThrowIfCancellationRequested();

                public void OnCompleted(Action continuation) => UnsafeOnCompleted(continuation);

                public void UnsafeOnCompleted(Action continuation) => PlayerLoopHelper.AddContinuation(timing, continuation);
            }

            YieldAwaiter awaiter;

            public YieldAwaitable(PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
            {
                awaiter = new YieldAwaiter(timing, cancellationToken);
            }

            public YieldAwaiter GetAwaiter() => awaiter;
        }

        #endregion

        [ReceiveZaContainer]
        public void Initialize(ReadonlyZaContainer container)
        {
            stateNodes = container.Get<StateNodeCollections>();

            var states = stateNodes.GetAll();
            foreach(UniTaskStateNode state in states)
                state.Initialize(container);
        }

        public StateNodeCollections StateNodes { get => stateNodes; }
        private StateNodeCollections stateNodes = null;
        private Queue<UniTaskStateNode> requestQueue = new Queue<UniTaskStateNode>();

        private UniTaskStateNode currentStateNode = null;        
        private CancellationTokenSource StateUpdateCancellation = null;

        public void Start()
        {
            StateUpdateCancellation = new CancellationTokenSource();

            UpdateAsync(StateUpdateCancellation.Token).Forget();
            GoTo(stateNodes.FirstState.GetType());
        }

        public void GoTo(Type state)
        {
            bool TryFind(Type type, out UniTaskStateNode res)
            {
                var target = stateNodes.Get(type) as UniTaskStateNode;

                if (target != null)
                {
                    res = target;
                    return true;
                }

                res = null;
                return false;
            }

            bool isSuccess = TryFind(state, out UniTaskStateNode res);

            if (isSuccess)
                requestQueue.Enqueue(res);
        }
        public void GoTo<T>() where T : IStateNode => GoTo(typeof(T));

        private async UniTask UpdateAsync(CancellationToken token)
        {
            YieldAwaitable oneFrame = new YieldAwaitable(PlayerLoopTiming.Update,token);

            while (!token.IsCancellationRequested)
            {
                if(requestQueue.Count > 0)
                {
                    if(token.IsCancellationRequested)
                        break;

                    var nextState = requestQueue.Dequeue();

                    if(currentStateNode != null)
                        await currentStateNode.OnExit(nextState,token);

                    if(token.IsCancellationRequested)
                        break;

                    await nextState.OnEnter(currentStateNode,token);
                    currentStateNode = nextState;
                }

                await oneFrame;

                if(!token.IsCancellationRequested && currentStateNode != null)
                    await currentStateNode.OnUpdate(token);
            }
        }

        public void Dispose()
        {
            StateUpdateCancellation?.Cancel();

            stateNodes.Dispose();            

            requestQueue.Clear();
            requestQueue = new Queue<UniTaskStateNode>();

            currentStateNode = null;
        }
    }
}