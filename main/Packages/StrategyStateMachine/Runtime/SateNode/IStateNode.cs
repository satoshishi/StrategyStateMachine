using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine
{
    public interface IStateNode : IDisposable
    {
        /// <summary>
        /// このState遷移時に呼び出される
        /// </summary>
        /// <param name="parameter"></param>
        void OnEnter(IStateNode previsouState);

        /// <summary>
        /// このStateに遷移している間、毎フレーム呼び出される
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// このStateを抜ける際に呼びだされる 
        /// </summary>
        /// <param name="nextState"></param>
        void OnExit(IStateNode nextState);
    }

    public interface IStateNode<STATE_PARAMETER, STATE_CHANGE_PARAMETER> : IStateNode
    {
        STATE_PARAMETER Parameter { get; }

        StateMachineService<STATE_PARAMETER, STATE_CHANGE_PARAMETER> StateMachine { get; }

        void Initialize(STATE_PARAMETER parameter, StateMachineService<STATE_PARAMETER, STATE_CHANGE_PARAMETER> stateMachine);

        /// <summary>
        /// 別のStateに遷移する
        /// </summary>
        /// <param name="parameter"></param>
        void ChangeState(STATE_CHANGE_PARAMETER parameter);
    }
}