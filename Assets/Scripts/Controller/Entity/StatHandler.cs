using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(0, 100)][SerializeField] private float health = 10;
    public float Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, 100);
    }

    [Range(1f, 20f)][SerializeField] private float speed = 3;
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
        
}