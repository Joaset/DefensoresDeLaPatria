using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationSelectPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject player;
    public Animator animationPlayer;

    void Start()
    {
        animationPlayer = player.GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        animationPlayer.SetBool("IsTouching", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animationPlayer.SetBool("IsTouching", false);
    }
}
