using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public struct EnemyStatus
    {
        public int maxHp;
        public int currentHp;
        public float speed;
        public int atkDmg;
    }
    public bool isDie = false;
    public EnemyStatus status;
    public EnemyStatus Status { get { return status; } }

    public void SettingStatus(int _maxHp, float _speed, int _atkDmg)
    {
        status = new EnemyStatus();
        status.maxHp = _maxHp;
        status.currentHp = _maxHp;
        status.speed = _speed;
        status.atkDmg = _atkDmg;
    }
    public void HitEnemy(int dmg)
    {
        status.currentHp -= dmg;
        if (status.currentHp <= 0)
            isDie = true;
    }
}
