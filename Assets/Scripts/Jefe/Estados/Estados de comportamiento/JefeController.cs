using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeController : MonoBehaviour
{
    [Header("Referencias")]
    public Animator animator;
    public Transform posJefe;
    public Transform player;
    public Rigidbody2D rb;

    [Header("Parámetros")]
    public float speed;
    public float rangoAtaque;
    public Transform[] esquinas;

    [Header("Vida")]
    public VidaJefeState vida;

    private FMSJefeState stateMachineJefe1;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //vida = GetComponent<VidaJefeState>();

        stateMachineJefe1 = new FMSJefeState(this);
        stateMachineJefe1.ChangeState(new IdleJefeState());
    }

    void Update()
    {
        stateMachineJefe1.Update();
    }

    public void ChangeState(IJefeState newState)
    {

        stateMachineJefe1.ChangeState(newState);
    }
}
