using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using StateMachine.Strategy;
using StateMachine.Node;

namespace StateMachine.Context
{
    public class StateMachineContext : IDisposable
    {
        private IStateMachineStrategy Strategy;

        public StateMachineContext(IStateMachineStrategy strategy)
        {
            Strategy = strategy;
        }

        public void Start() => Strategy.Start();

        public void GoTo<T>() where T : IStateNode => Strategy.GoTo<T>();

        public void GoTo(Type state) => Strategy.GoTo(state);

        public void Dispose() => Strategy.Dispose();
    }
}