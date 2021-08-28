using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using StateMachine.Node;

namespace StateMachine.Main
{
    public interface IStateMachine<STATE_NODE> : IDisposable where STATE_NODE : IStateNode
    {
        StateNodeCollections<STATE_NODE> StateNodes { get; }
        STATE_NODE CurrentState { get; }

        void Build(StateNodeCollections<STATE_NODE> stateNodes);
        void GoTo<T>() where T : IStateNode;
        void GoTo(Type state);
    }
}