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

        public STATE_NODE CurrentState { get => StateMachine.CurrentState; }

        public void Build() => StateMachine.Build(StateNodes);

        public void Replace(IStateMachine<STATE_NODE> stateMachine)
        {
            StateMachine?.Dispose();
            StateMachine = stateMachine;
        }

        public void Replace(StateNodeCollections<STATE_NODE> stateNodes)
        {
            StateNodes?.Dispose();
            StateNodes = stateNodes;
        }

        public void Replace(IStateMachine<STATE_NODE> stateMachine, StateNodeCollections<STATE_NODE> stateNodes)
        {
            Replace(stateNodes);
            Replace(stateMachine);
        }

        public void GoTo<T>() where T : IStateNode => StateMachine.GoTo<T>();

        public void GoTo(Type state) => StateMachine.GoTo(state);

        public void Dispose() => StateMachine.Dispose();
    }
}