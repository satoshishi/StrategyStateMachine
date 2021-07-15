using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace StateMachine.Node
{
    public class StateNodeCollections : IDisposable
    {
        protected IEnumerable<IStateNode> Collections { get; set; } = null;

        public IStateNode FirstState { get; protected set; }

        public StateNodeCollections(IEnumerable<IStateNode> collections, IStateNode firstState)
        {
            Collections = collections;
            FirstState = firstState;
        }

        public virtual IStateNode Get<T>() where T : IStateNode => Get(typeof(T));

        public virtual IStateNode Get(Type type)
        {
            var target = Collections.ToList().Find(s => s.GetType() == type);

            return target == null ? default : target;            
        }

        public virtual IReadOnlyList<IStateNode> GetAll() => Collections.ToList().AsReadOnly();

        public virtual void Dispose()
        {
            Collections.ToList().Clear();
        }
    }
}