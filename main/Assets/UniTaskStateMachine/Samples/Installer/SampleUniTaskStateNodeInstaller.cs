using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZaCo.Core;
using UniTaskSTM.Node;
using StateMachine.Node;

namespace ZaCo.Helper
{
    public class SampleUniTaskStateNodeInstaller : InstallDecorator
    {
        public override ZaContainer Install(ZaContainer container)
        {
            var nodes = new List<UniTaskStateNode>()
            {
                new SampleUniTaskStateA(),
                new SampleUniTaskStateB()
            };

            container.Register<StateNodeCollections>(
                new StateNodeCollections(nodes,nodes[0]));

            return container;
        }
    }
}