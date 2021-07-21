using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Node
{
    public class Sample01StateB : SimplyStateNode
    {
        public override void OnEnter(SimplyStateNode from)
        {
            Debug.Log("B enter");
        }

        public override void OnExit(SimplyStateNode to)
        {
            Debug.Log("B exit");
        }
    }
}