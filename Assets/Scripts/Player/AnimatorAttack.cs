using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAttack : MonoBehaviour
{
    private PlayerController player;
    public Animator anim;

    private void Awake() {
        player = GetComponentInParent<PlayerController>();
    }

    public void EnabledPickup(){
        player.EnabledPickup();
    }

    public void DisabledPickup(){
        player.DisabledPickup();
    }

    public void EnableHitbox() {
        player.EnableHitboxPunch();
    }

    public void DisableHitbox() {
        player.DisableHitboxPunch();
    }

    public void EnableKickbox() {
        player.EnableKickbox();
    }

    public void DisableKickbox() {
        player.DisableKickbox();
    }

    public void EnableAirKickbox() {
        player.EnableAirKickbox();
    }

    public void DisableAirKickbox() {
        player.DisableAirKickbox();
    }
}
