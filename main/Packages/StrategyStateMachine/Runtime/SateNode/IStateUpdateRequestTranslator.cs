using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine
{
    public interface IStateUpdateRequestTranslator<FROM,TO> where TO : IStateNode
    {
        TO Handle(FROM parameter);
    }
}