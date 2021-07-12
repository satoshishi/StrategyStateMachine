using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace StatMachine.Strategy
{
    public interface IStateMachineStrategy<STATE_NODE> : IDisposable
    {
        IEnumerable<STATE_NODE> StateNodes{get;}
        void GoTo<T>() where T : STATE_NODE;
        void GoTo(Type state);
    }
}