using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : StatHandler
{/*
    public class EnemyStatus : StatHandler
    {
        public int maxHp;
        public int atkDmg;
    }
    public bool isDie = false;
    public EnemyStatus status;
    public EnemyStatus Status { get { return status; } }
*/
    public string name = "none";
    public void SettingStatus(int _maxHp, float _speed, int _atkDmg, string _name = "none")
    {
        //        status = new EnemyStatus();
        name = _name;
        Health = _maxHp;
        //status.Health = _maxHp;
        Speed = _speed;
    }
    /*
        public void HitEnemy(int dmg)
        {
            status.Health -= dmg;
            if (status.Health <= 0)
                isDie = true;
        }

        public EnemyStatus GetStatus()
        {
            return status;
        }*/
}
