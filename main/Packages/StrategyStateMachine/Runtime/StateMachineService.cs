using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public sealed class StateMachineService<STATE_PARAMETER, STATE_CHANGE_PARAMETER>
    {
        private IStateNodeList stateNodeList;

        private IStateUpdateRequestTranslator<STATE_CHANGE_PARAMETER, IStateNode> translator;

        private IStateMachine stateMachine;

        public StateMachineService(IStateNodeList stateNodeList, IStateMachine stateMachine, IStateUpdateRequestTranslator<STATE_CHANGE_PARAMETER, IStateNode> translator)
        {
            this.stateNodeList = stateNodeList;
            this.translator = translator;
            this.stateMachine = stateMachine;
        }

        /// <summary>
        /// StateNode群のInitializeを実行した後に一番最初のStateに遷移する
        /// </summary>
        /// <param name="parameter"></param>
        public void initialize(STATE_PARAMETER parameter)
        {
            foreach (IStateNode stateNode in stateNodeList.Nodes)
            {
                var target = stateNode as IStateNode<STATE_PARAMETER,STATE_CHANGE_PARAMETER>;
                target.Initialize(parameter,this);
            }

            ChangeToFirstState();
        }

        /// <summary>
        /// 対象のStateに遷移する
        /// </summary>
        /// <param name="parameter"></param>
        public void ChangeState(STATE_CHANGE_PARAMETER parameter)
        {
            var target = translator.Handle(parameter);
            stateMachine.ChangeState(target);
        }

        /// <summary>
        /// 一番最初に設定されているStateに遷移する
        /// </summary>
        public void ChangeToFirstState()
        {
            stateMachine.ChangeState(stateNodeList.FirstState);
        }

        /// <summary>
        /// StateNode群を新しいものに切り替える
        /// 切り替える前に既存のStateNode群をDisposeする
        /// </summary>
        /// <param name="newStateNodeList"></param>
        public void ChangeStateNodeList(IStateNodeList newStateNodeList)
        {
            stateNodeList?.Dispose();
            stateNodeList = null;

            stateNodeList = newStateNodeList;
        }
    }
}