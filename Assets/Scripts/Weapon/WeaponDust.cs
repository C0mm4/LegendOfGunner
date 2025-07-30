using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDust : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.AddComponent<Rigidbody2D>();
        float randX, randY;
        // Add Random Force
        randX = Random.Range(-1f, 1f);
        randY = Random.Range(.5f, 1.5f);
        Debug.Log(randX);
        Debug.Log(randY);
        body.AddForce(new Vector2(randX, randY), ForceMode2D.Impulse);
        body.bodyType = RigidbodyType2D.Kinematic;

        // color is Dark Gray
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.color = Color.white * 0.3f;

        // Set Background Layer
        sprite.sortingOrder = 51;

        Destroy(gameObject, 3f);
        Invoke("RemoveRigidbody", 1f);
    }

    public void Update()
    {
        if (body != null)
        {
            body.position += body.velocity * Time.deltaTime;
            body.velocity += Physics2D.gravity * 0.2f * Time.deltaTime;
        }
    }

    private void RemoveRigidbody()
    {
        body.simulated = false;
        body = null;
        Debug.Log("Body Dead");
    }
}
