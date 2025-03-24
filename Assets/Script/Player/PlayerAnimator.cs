
using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    [SerializeField] private SpriteRenderer _spriteRenderer;
  
    private void Awake()
    {
        this.playerAnim = GetComponent<Animator>();

    }

    public void SetTriggerAnim(string name)
    {
        this.playerAnim.SetTrigger(name);
    }

    public void SetIdleDirection(string name, float index)
    {
        this.playerAnim.SetFloat(name, index);
    }    

}