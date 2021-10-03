using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Sample02RequestTranslator : IStateUpdateRequestTranslator<Sample02StateNode, IStateNode>
{
    public IStateNode Handle(Sample02StateNode parameter) => parameter;
}
