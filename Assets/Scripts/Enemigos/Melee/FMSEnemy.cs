using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMSEnemy : MonoBehaviour
{
    public IState CurrentState { get; private set; }

    public void Initialize(IState startState)
    {
        CurrentState = startState;
        startState.Enter();
    }

    public void ChangeState(IState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
