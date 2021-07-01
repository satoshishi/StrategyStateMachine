using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using StatMachine.Observer;

namespace StatMachine.Strategy
{
    public class SimpleStateMachineStrategy : IStateMachineStrategy<ISimpleStateNode>, ISimplyObserver<Type>
    {
        public IEnumerable<ISimpleStateNode> StateNodes { get => stateNodes; }
        private List<ISimpleStateNode> stateNodes = new List<ISimpleStateNode>();
        private Queue<ISimpleStateNode> requestQueue = new Queue<ISimpleStateNode>();

        private bool isProcessingStateUpdate = false;
        private ISimpleStateNode currentStateNode = null;

        public SimpleStateMachineStrategy(IEnumerable<ISimpleStateNode> stateNodes)
        {
            this.stateNodes = stateNodes.ToList();

            foreach(ISimpleStateNode node in stateNodes)
                node.OnRequest.Subscribe(this);
        }

        public void OnNext(Type next) => GoTo(next);

        public void GoTo(Type state)
        {
            bool isSuccess = TryFind(state, out ISimpleStateNode target);

            if (isSuccess)
                requestQueue.Enqueue(target);

            if (!isProcessingStateUpdate)
                UpdateState();
        }

        public void GoTo<T>() where T : ISimpleStateNode => GoTo(typeof(T));

        public void UpdateState()
        {
            while (true)
            {
                if (requestQueue.Count <= 0)
                {
                    requestQueue.Clear();
                    requestQueue = new Queue<ISimpleStateNode>();
                    break;
                }

                isProcessingStateUpdate = true;
                var nextState = requestQueue.Dequeue();

                if (currentStateNode != null)
                    currentStateNode.OnExit(nextState);

                nextState.OnEnter(currentStateNode);
                currentStateNode = nextState;
            }

            isProcessingStateUpdate = false;
        }

        public bool TryFind(Type type, out ISimpleStateNode state)
        {
            var target = stateNodes.Find(s => s.GetType() == type);

            if (target != null)
            {
                state = target;
                return true;
            }

            state = null;
            return false;
        }



        public void Dispose()
        {
            foreach (ISimpleStateNode node in stateNodes)
                node.Dispose();

            stateNodes.Clear();
            stateNodes = new List<ISimpleStateNode>();

            requestQueue.Clear();
            requestQueue = new Queue<ISimpleStateNode>();

            currentStateNode = null;
            isProcessingStateUpdate = false;
        }
    }
}