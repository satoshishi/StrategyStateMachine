using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZaCo.Core;
using ZaCo.Helper;
using StateMachine.Context;
using UniTaskSTM.Node;

public class SampleUniTaskStateMachineMain : MonoBehaviour
{
    [SerializeField]
    private InstallHelper m_installer;

    private ReadonlyZaContainer Container;

    // Start is called before the first frame update
    void Start()
    {
        var container = ZaContainer.Create();
        m_installer.Handle(OnInstalled);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            Container.Get<StateMachineContext>().GoTo<SampleUniTaskStateB>();
            Container.Get<StateMachineContext>().GoTo<SampleUniTaskStateA>();   
        }

//        if (Input.GetKeyUp(KeyCode.S))
  //          Container.Get<StateMachineContext>().GoTo<SampleUniTaskStateA>();            
    }

    private void OnInstalled(ReadonlyZaContainer container)
    {
        Container = container;
        container.Get<StateMachineContext>().Start();
    }

    private void OnDisable()
    {
        Container.Get<StateMachineContext>().Dispose();
        Container.Dispose();

        Debug.Log("disposed");
    }
}
