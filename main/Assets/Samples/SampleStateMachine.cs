using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class SampleStateMachine : MonoBehaviour, IStateMachine
{
    private Queue<IStateNode> requestQueue = new Queue<IStateNode>();
    private IStateNode currentStateNode = null;

    public void ChangeState(IStateNode target)
    {
        requestQueue.Enqueue(target);
    }

    private void Update()
    {
        if (requestQueue.Count > 0)
        {
            var nextState = requestQueue.Dequeue();

            if (currentStateNode != null)
                currentStateNode.OnExit(nextState);

            nextState.OnEnter(currentStateNode);
            currentStateNode = nextState;
        }

        if (currentStateNode != null)
            currentStateNode.OnUpdate();
    }

    public void Dispose()
    {
        currentStateNode = null;
        requestQueue.Clear();
        requestQueue = null;
    }
}
