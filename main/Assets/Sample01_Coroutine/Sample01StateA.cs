using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Node
{
    public class Sample01StateA : SimplyStateNode
    {
        public override void OnEnter(SimplyStateNode from)
        {
            Debug.Log("A enter");   
        }

        public override void OnExit(SimplyStateNode to)
        {
            Debug.Log("A exit");
        }
    }
}