using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Sample01 : MonoBehaviour
{
    [SerializeField]
    private SampleStateMachine m_stateMachine;

    private StateMachineService<int, int> stateMachineService;

    // Start is called before the first frame update
    void Start()
    {
        var targets = new List<IStateNode>()
        {
            new Sample01StateA(),
            new Sample01StateB()
        };
        var nodes = new StateNodeList(
            targets,
            targets[0]
        );

        stateMachineService = new StateMachineService<int, int>(
            nodes,
            m_stateMachine,
            new Sample01RequestTranslator(nodes));

        stateMachineService.initialize(100);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
