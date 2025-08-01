using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BossView : EnemyView
{
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void AttackAnimation(int idx)
    {
        animator.SetTrigger("SpawnEnemy");
    }

    public override void HitAnimaion()
    {
        animator.SetTrigger("BossHit");
    }
}
