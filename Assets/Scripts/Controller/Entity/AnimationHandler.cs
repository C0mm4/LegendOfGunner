using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    private static readonly int IsDie = Animator.StringToHash("IsDie");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Damage()
    {
        animator.SetBool(IsDamage, true);
    }

    public void InvicibillityEnd()
    {
        animator.SetBool(IsDamage, false);
    }

    public void Die()
    {
        animator.SetBool(IsDie, true);
        
    }
}
