using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public abstract class Sample02StateNode : MonoBehaviour, IStateNode<int, Sample02StateNode>
{
    public int Id { get; protected set; } = -1;

    private int parameter;
    public int Parameter { get => parameter; }

    private StateMachineService<int, Sample02StateNode> stateMachine;
    public StateMachineService<int, Sample02StateNode> StateMachine { get => stateMachine; }

    public void Initialize(int parameter, StateMachineService<int, Sample02StateNode> stateMachine)
    {
        this.parameter = parameter;
        this.stateMachine = stateMachine;

        OnInitialize();
    }

    protected virtual void OnInitialize()
    {

    }

    /// <summary>
    /// 別のStateに遷移する
    /// </summary>
    /// <param name="parameter"></param>
    public virtual void ChangeState(Sample02StateNode parameter)
    {
        stateMachine.ChangeState(parameter);
    }

    /// <summary>
    /// このState遷移時に呼び出される
    /// </summary>
    /// <param name="parameter"></param>
    public abstract void OnEnter(IStateNode previsouState);

    /// <summary>
    /// このStateに遷移している間、毎フレーム呼び出される
    /// </summary>
    public virtual void OnUpdate()
    {

    }

    /// <summary>
    /// このStateを抜ける際に呼びだされる 
    /// </summary>
    /// <param name="nextState"></param>
    public abstract void OnExit(IStateNode nextState);

    public virtual void Dispose()
    {

    }
}
