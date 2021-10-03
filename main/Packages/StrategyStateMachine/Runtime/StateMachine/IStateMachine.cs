using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine
{
    public interface IStateMachine : IDisposable
    {   
        void ChangeState(IStateNode target);    
    }
}