using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZaCo.Core;
using UniTaskSTM.StateMachine;
using StateMachine.Context;
using StateMachine.Strategy;
using ZaCo.Helper;

namespace UniTaskSTM.Installer
{
    public class UniTaskStateMachineInstaller : InstallDecorator
    {
        public override ZaContainer Install(ZaContainer container)
        {
            container.Register<IStateMachineStrategy>(new UniTaskStateMachine());
            container.Register<StateMachineContext>(new StateMachineContext(container.Get<IStateMachineStrategy>()));

            return container;
        }
    }
}