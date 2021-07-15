using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using ZaCo.Core;
using StateMachine.Node;

namespace UniTaskSTM.Node
{
    public abstract class UniTaskStateNode : IStateNode
    {
        protected ReadonlyZaContainer Container{get;set;} = null;

        public virtual void Initialize(ReadonlyZaContainer container)
        {
            Container = container;
        }

        public abstract UniTask OnEnter(UniTaskStateNode from, CancellationToken token);

        public abstract UniTask OnUpdate(CancellationToken token);

        public abstract UniTask OnExit(UniTaskStateNode to, CancellationToken token);
    }
}