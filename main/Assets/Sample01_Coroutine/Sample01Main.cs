using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine.Main;
using StateMachine.Context;
using StateMachine.Node;

public class Sample01Main : MonoBehaviour
{

    [SerializeField]
    private CoroutineStateMachine stateMachine1;

    [SerializeField]
    private WaitOneSecondsStateMachine stateMachine2;

    private StateMachineContext<SimplyStateNode> context;

    // Start is called before the first frame update
    void Start()
    {
        StateNodeCollections<SimplyStateNode> nodes = new StateNodeCollections<SimplyStateNode>(
            new List<SimplyStateNode>()
            {
                new Sample01StateA(),
                new Sample01StateB()
            },
            typeof(Sample01StateA)
        );

        context = new StateMachineContext<SimplyStateNode>();
        context.Build(stateMachine1, nodes);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
            context.GoTo<Sample01StateB>();
        if (Input.GetKeyUp(KeyCode.S))
            context.GoTo<Sample01StateA>();
        if (Input.GetKeyUp(KeyCode.D))
            context.Build(stateMachine2);
    }
}
