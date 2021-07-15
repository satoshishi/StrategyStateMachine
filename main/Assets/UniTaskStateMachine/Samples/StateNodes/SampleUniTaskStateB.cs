using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace UniTaskSTM.Node
{
    public class SampleUniTaskStateB : UniTaskStateNode
    {
        public override async UniTask OnEnter(UniTaskStateNode from, CancellationToken token)
        {
           Debug.Log($"{this.GetType()} Enter");
        }

        public override async UniTask OnUpdate(CancellationToken token)
        {
           Debug.Log($"{this.GetType()} Update");
        }

        public override async UniTask OnExit(UniTaskStateNode to, CancellationToken token)
        {
           Debug.Log($"{this.GetType()} Exit");
        }
    }
}
