using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using StatMachine.Strategy;

namespace StatMachine.Context
{
    public class StateMachineContext<STATE_NODE> : IDisposable
    {
        private IStateMachineStrategy<STATE_NODE> Strategy;

        public StateMachineContext(
            IStateMachineStrategy<STATE_NODE> strategy
        )
        {
            Strategy = strategy;
        }

        public StateMachineContext(
            IStateMachineStrategy<STATE_NODE> strategy,
            STATE_NODE firstState
        )
        {
            Strategy = strategy;
            Strategy.GoTo(firstState.GetType());
        }        

        public void GoTo<T>() where T : STATE_NODE
        {
            Strategy.GoTo<T>();
        }

        public void GoTo(Type state)
        {
            Strategy.GoTo(state);
        }

        public void Dispose()
        {
            Strategy.Dispose();
            Strategy = null;
        }
    }
}