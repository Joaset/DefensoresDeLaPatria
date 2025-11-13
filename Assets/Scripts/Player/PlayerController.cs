using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject kickbox;
    [SerializeField] private GameObject airkickbox;
    [SerializeField] private GameObject pickupbox;
    private FMSPlayer stateMachine;
    public FMSPlayer StateMachine => stateMachine;
    public Vector2 mov { get; private set; }
    public Transform Visual;//es el sprite renderer
    public Animator ani;
    [HideInInspector] public PowerUps pp;
    public PlayerHealth health;
    
    public float moveSpeed = 5f;
    public bool isJumping;
    public bool canJump = true;
    private bool movementEnabled = true;

    void Start() {
        stateMachine = new FMSPlayer();
        stateMachine.ChangeState(new IdleState(this));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            StateMachine.ChangeState(new JumpState(this));
        }

        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//permite moverse cuando se aprieta el espacio

        stateMachine.Update();
    }

    public bool IsNearPowerUp()
    {
        return pp != null && pp.playerInRange;
    }

    public void SetMovementEnabled(bool state)
    {
        movementEnabled = state;
    }

    public bool IsMovementEnabled()
    {
        return movementEnabled;
    }

    public void EnabledPickup()
    {
        pickupbox.SetActive(true);
    }

    public void DisabledPickup()
    {
        pickupbox.SetActive(false);
    }

    public void ChangeStatetoHurt(){
        StateMachine.ChangeState(new HurtState(this));
    }

    public void EnableHitboxPunch() {
        hitbox.SetActive(true);
    }

    public void DisableHitboxPunch() {
        hitbox.SetActive(false);
    }

    public void EnableKickbox() {
        kickbox.SetActive(true);
    }

    public void DisableKickbox() {
        kickbox.SetActive(false);
    }

    public void EnableAirKickbox() {
        airkickbox.SetActive(true);
    }

    public void DisableAirKickbox() {
        airkickbox.SetActive(false);
    }
}
