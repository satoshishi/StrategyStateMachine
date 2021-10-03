using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Sample02 : MonoBehaviour
{
    [SerializeField]
    private SampleStateMachine m_stateMachine;

    [SerializeField]
    private Sample02StateNodeListObject m_list1;

    [SerializeField]
    private Sample02StateNodeListObject m_list2;

    private StateMachineService<int, Sample02StateNode> stateMachineService;

    // Start is called before the first frame update
    void Start()
    {
        stateMachineService = new StateMachineService<int, Sample02StateNode>(
            m_list1,
            m_stateMachine,
            new Sample02RequestTranslator());

        stateMachineService.initialize(100);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            stateMachineService.ChangeStateNodeList(m_list2);
            stateMachineService.initialize(100);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            stateMachineService.ChangeStateNodeList(m_list1);
            stateMachineService.initialize(100);
        }

    }
}
