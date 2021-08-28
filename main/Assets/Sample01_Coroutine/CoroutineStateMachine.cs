using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine.Node;
using System;

namespace StateMachine.Main
{
    public class CoroutineStateMachine : MonoBehaviour, IStateMachine<SimplyStateNode>
    {
        public StateNodeCollections<SimplyStateNode> StateNodes { get => stateNodes; }
        private StateNodeCollections<SimplyStateNode> stateNodes = null;
        public SimplyStateNode CurrentState { get => currentStateNode; }
        private SimplyStateNode currentStateNode = null;

        private Queue<SimplyStateNode> requestQueue = new Queue<SimplyStateNode>();
        private Coroutine activeLoop = null;

        public void Build(StateNodeCollections<SimplyStateNode> stateNode)
        {
            this.stateNodes = stateNode;

            activeLoop = StartCoroutine(UpdateStateMachine());
            GoTo(stateNodes.FirstState);
        }

        public void GoTo(Type state)
        {
            if (currentStateNode != null && state == currentStateNode.GetType())
                return;

            var next = StateNodes.Get(state);

            if (next != null)
                requestQueue.Enqueue(next);
        }
        public void GoTo<T>() where T : IStateNode => GoTo(typeof(T));

        private IEnumerator UpdateStateMachine()
        {
            while (true)
            {
                if (requestQueue.Count > 0)
                {
                    var nextState = requestQueue.Dequeue();

                    if (currentStateNode != null)
                        currentStateNode.OnExit(nextState);

                    nextState.OnEnter(currentStateNode);
                    currentStateNode = nextState;
                }

                if (currentStateNode != null)
                    currentStateNode.OnUpdate();

                yield return null;
            }
        }

        public void Dispose()
        {
            if (activeLoop != null)
                StopCoroutine(activeLoop);

            currentStateNode?.OnExit(currentStateNode);

            stateNodes.Dispose();
            requestQueue.Clear();
            requestQueue = new Queue<SimplyStateNode>();

            currentStateNode = null;
        }

    }
}