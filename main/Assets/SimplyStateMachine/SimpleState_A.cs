using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatMachine.Observer;
using System;

public class SimpleState_A : ISimpleStateNode
{
    public SimplyObservable<Type> OnRequest{get => onRequeset;}
    private SimplyObservable<Type> onRequeset = new SimplyObservable<Type>();

    public void OnEnter(ISimpleStateNode from)
    {
        Debug.Log("A Enter");
    }

    public void OnExit(ISimpleStateNode to)
    {
        Debug.Log("A Exit");
    }  

    public void Dispose()
    {
        onRequeset.Dispose();
    }
}
