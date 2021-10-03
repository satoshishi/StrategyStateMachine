using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Sample01StateB : Sample01StateNode
{
    protected override void OnInitialize()
    {
        Id = 2;
    }
    public override void OnEnter(IStateNode previsouState)
    {
        Debug.Log("Entered : " + this.GetType());
    }

    public override void OnUpdate()
    {
        if(Input.GetKeyUp(KeyCode.A))
            ChangeState(1);
    }

    public override void OnExit(IStateNode nextState)
    {

    }
}
