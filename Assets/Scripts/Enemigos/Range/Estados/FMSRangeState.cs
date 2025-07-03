using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMSRangeState
{
    public IState currentState { get; private set; }

    public void Initialize(IState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(IState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public IState State(){
        return currentState;
    }

    public void Update()
    {
        currentState.Update();
    }
}
