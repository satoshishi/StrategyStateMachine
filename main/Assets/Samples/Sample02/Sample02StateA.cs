using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Sample02StateA : Sample02StateNode
{
    [SerializeField]
    private string message;

    [SerializeField]
    private Sample02StateNode nextState;

    public override void OnEnter(IStateNode previsouState)
    {
        Debug.Log(message);
    }

    public override void OnUpdate()
    {
        if (Input.GetKeyUp(KeyCode.A))
            ChangeState(nextState);
    }

    public override void OnExit(IStateNode nextState)
    {

    }
}
