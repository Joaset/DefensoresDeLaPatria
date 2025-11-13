using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMSJefeState
{
    private IJefeState estadoActual;
    private JefeController jefe;

    public FMSJefeState(JefeController jefe) => this.jefe = jefe;

    public void ChangeState(IJefeState newState)
    {
        estadoActual?.Exit();
        estadoActual = newState;
        estadoActual.Enter(jefe);
    }

    public void Update() => estadoActual?.Update();
}
