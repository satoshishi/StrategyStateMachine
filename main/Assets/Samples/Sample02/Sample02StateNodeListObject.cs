using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using StateMachine;

public class Sample02StateNodeListObject : MonoBehaviour, IStateNodeList
{
    [SerializeField]    
    private List<Sample02StateNode> nodes;
    public IReadOnlyCollection<IStateNode> Nodes { get => nodes;}

    [SerializeField]
    private Sample02StateNode firstState;
    public IStateNode FirstState { get => firstState; }

    public IStateNode Find(System.Predicate<IStateNode> match)
    {
        return nodes.Find(match);
    }

    public void Add(IStateNode newNode)
    {
        nodes.Add(newNode as Sample02StateNode);
    }

    public void Dispose()
    {
        foreach (IStateNode node in nodes)
            node.Dispose();
    }
}
