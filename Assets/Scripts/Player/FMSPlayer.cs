using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMSPlayer{
    private IState currentState;

    public void ChangeState(IState newState) {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update() {
        currentState?.Update();
    }
}
