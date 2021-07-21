using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Node
{
    public abstract class SimplyStateNode : IStateNode
    {
        public abstract void OnEnter(SimplyStateNode from);

        public virtual void OnUpdate()
        {

        }

        public abstract void OnExit(SimplyStateNode to);

        public virtual void Dispose()
        {            
        }
    }
}