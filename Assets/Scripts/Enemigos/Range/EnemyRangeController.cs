using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeController : MonoBehaviour
{
    public float speed;
    public float visionDistance;
    public float attackRange;
    public Transform shootPoint;
    //public GameObject weaponPrefab;
    public Animator animator;
    public int maxHealth;
    public float timer;

    //para el spawn de enemigos
    public delegate void DeathHandler();
    public event DeathHandler OnDeath;

    [HideInInspector] public int currentHealth;
    [HideInInspector] public Transform player;
    public FMSRangeState StateMachine { get; private set; }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        StateMachine = new FMSRangeState();
        StateMachine.Initialize(new IdleRangeState(this));
        currentHealth = maxHealth;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        StateMachine.Update();
    }

    public void EnableShoot() {
        if (StateMachine.currentState is AttackRangeState attackState)
        {
            attackState.Shoot();
        }
    }

    public void DisableShoot() {
        StateMachine.ChangeState(new IdleRangeState(this));
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            StateMachine.ChangeState(new DeadRangeState(this));
            Die();
        }
        else
        {
            StateMachine.ChangeState(new HurtRangeState(this));
        }
    }
    
    public void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
