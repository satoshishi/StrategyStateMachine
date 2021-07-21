using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Node
{
    public class Sample01StateC : SimplyStateNode
    {
        public override void OnEnter(SimplyStateNode from)
        {
            Debug.Log("C enter");
        }

        public override void OnExit(SimplyStateNode to)
        {
            Debug.Log("C exit");
        }
    }
}