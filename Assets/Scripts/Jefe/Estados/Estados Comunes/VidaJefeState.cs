using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJefeState : IJefeState
{
    public float vidaMax = 200;
    private float vidaActual;

    private void Awake()
    {
        vidaActual = vidaMax;
    }

    public void Enter(JefeController jefe){}

    public void Update(){}

    public void Exit(){}

    public void TakeDamage(float cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        Debug.Log($"Jefe recibió daño. Vida: {vidaActual}");
    }

    public bool IsDead()
    {
        return vidaActual <= 0;
    }
}
