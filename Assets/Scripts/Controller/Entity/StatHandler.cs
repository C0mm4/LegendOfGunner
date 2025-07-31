using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    private float health = 10;
    public float Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, MaxHealth);
    }

    private float maxHealth;
    public float MaxHealth
    {
        get => health;
        set => maxHealth = Mathf.Clamp(value, 0, 100);
    }

    private float speed = 3;
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }

    private int level = 1;
    public int Level
    {
        get => level;
        set => level = Mathf.Clamp(value, 0, 20);
        set => level = Mathf.Clamp(value, 1, 20);
    }

        
}