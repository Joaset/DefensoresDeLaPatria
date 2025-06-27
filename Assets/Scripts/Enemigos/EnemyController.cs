using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    public Transform player;
    public Animator animator;
    public float speed = 2f;
    public float attackRange = 1.5f;
    public float health;
    public bool mira = true;

    public FMSEnemy StateMachine { get; private set; }

    private void Awake()
    {
        StateMachine = new FMSEnemy();
    }

    private void Start()
    {
        StateMachine.Initialize(new WalkState(this));
    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
            StateMachine.ChangeState(new DeathEnemyState(this));
        else
            StateMachine.ChangeState(new HurtEnemyState(this));
    }

    public void ChageStatetoDie(){
        StateMachine.ChangeState(new DeathEnemyState(this));
    }

    public void ChangeStatetoHurt(){
        StateMachine.ChangeState(new HurtEnemyState(this));
    }

    public void EnableHitboxPunch() {
        hitbox.SetActive(true); // o hitbox.GetComponent<Collider2D>().enabled = true;
    }

    public void DisableHitboxPunch() {
        hitbox.SetActive(false); // o hitbox.GetComponent<Collider2D>().enabled = false;
    }
}
