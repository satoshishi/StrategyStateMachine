using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using StateMachine.Main;
using StateMachine.Node;

namespace StateMachine.Context
{
    public sealed class StateMachineContext<STATE_NODE> : IDisposable where STATE_NODE : IStateNode
    {
        private IStateMachine<STATE_NODE> StateMachine;

        private StateNodeCollections<STATE_NODE> StateNodes;

        public void Build(IStateMachine<STATE_NODE> stateMachine, StateNodeCollections<STATE_NODE> stateNode, bool disposeStateMachine = true, bool disposeStateNode = true)
        {
            if (disposeStateMachine)
                StateMachine?.Dispose();

            if (disposeStateNode)
                StateNodes?.Dispose();

            StateMachine = stateMachine;
            StateNodes = stateNode;

            StateMachine.Build(StateNodes);
        }

        public void Build(IStateMachine<STATE_NODE> stateMachine)
        {
            Build(stateMachine, StateNodes, true, false);
        }

        public void Build(StateNodeCollections<STATE_NODE> stateNode)
        {
            Build(StateMachine, stateNode, false, true);
        }

        public void GoTo<T>() where T : IStateNode => StateMachine.GoTo<T>();

        public void GoTo(Type state) => StateMachine.GoTo(state);

        public void Dispose() => StateMachine.Dispose();
    }
}