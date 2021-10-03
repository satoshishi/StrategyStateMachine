using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Sample01RequestTranslator : IStateUpdateRequestTranslator<int, IStateNode>
{
    StateNodeList stateNodeList;

    public Sample01RequestTranslator(StateNodeList stateNodeList)
    {
        this.stateNodeList = stateNodeList;
    }

    public IStateNode Handle(int parameter)
    {
        foreach(IStateNode node in stateNodeList.Nodes)
        {
            var target = node as Sample01StateNode;
            if(target.Id == parameter)
                return target;
        }

        return default;
    }
}
