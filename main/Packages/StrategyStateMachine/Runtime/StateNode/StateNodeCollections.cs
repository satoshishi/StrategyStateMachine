using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace StateMachine.Node
{
    public sealed class StateNodeCollections<STATE_NODE> : IDisposable where STATE_NODE : IStateNode
    {
        public IEnumerable<STATE_NODE> Collections { get; private set; } = null;

        public Type FirstState { get; private set; }

        public StateNodeCollections(IEnumerable<STATE_NODE> collections, Type firstState)
        {
            Collections = collections;
            FirstState = firstState;
        }

        public T Get<T>() where T : STATE_NODE => ((T)(Get(typeof(T))));

        public STATE_NODE Get(Type type)
        {
            var target = Collections.ToList().Find(s => s.GetType() == type);

            return target == null ? default : target;            
        }

        public IReadOnlyList<STATE_NODE> GetAll() => Collections.ToList().AsReadOnly();

        public void Dispose()
        {
            foreach(STATE_NODE state in Collections)
                state.Dispose();
            
            Collections.ToList().Clear();
        }
    }
}