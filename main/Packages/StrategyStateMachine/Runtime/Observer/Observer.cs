using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine.Observer
{
    public interface ISimplyObserver<T>
    {
        void OnNext(T value);
    }
}