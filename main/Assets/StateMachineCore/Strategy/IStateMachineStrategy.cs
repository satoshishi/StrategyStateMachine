using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using StateMachine.Node;

namespace StateMachine.Strategy
{
    public interface IStateMachineStrategy : IDisposable
    {
        StateNodeCollections StateNodes{get;}

        void Start();
        void GoTo<T>() where T : IStateNode;
        void GoTo(Type state);
    }
}