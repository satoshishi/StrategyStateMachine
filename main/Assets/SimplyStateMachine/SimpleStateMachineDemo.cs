using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatMachine.Context;
using StatMachine.Strategy;

public class SimpleStateMachineDemo : MonoBehaviour
{
    private StateMachineContext<ISimpleStateNode> context;

    // Start is called before the first frame update
    void Start()
    {
        context = new StateMachineContext<ISimpleStateNode>(
            new SimpleStateMachineStrategy(
                new List<ISimpleStateNode>
                {
                    new SimpleState_A(),
                    new SimpleState_B()
                }
            ));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            context.GoTo<SimpleState_A>();
            context.GoTo<SimpleState_B>();
        }
    }
}
