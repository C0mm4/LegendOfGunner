using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput PlayerInput;
    [SerializeField] private float speed;

    private void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (PlayerInput != null)
        {
            transform.position += PlayerInput.dir * Time.deltaTime * speed;
        }
    }
}
