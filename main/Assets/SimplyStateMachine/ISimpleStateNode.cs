using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatMachine.Observer;
using System;

public interface ISimpleStateNode : IDisposable
{
    SimplyObservable<Type> OnRequest{get;}

    void OnEnter(ISimpleStateNode from);

    void OnExit(ISimpleStateNode to);    
}
