using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float scale;

    void Awake()
    {
        //rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        //rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Start()
    {
        scale = transform.localScale.x;
    }

    void FixedUpdate()
    {
        int animationFlipMultiplier = -1;
        if (((Vector2)GetComponent<Rigidbody2D>().velocity).x < 0)
        {
            animationFlipMultiplier = 1;
        }
        transform.localScale = new Vector3(animationFlipMultiplier * scale, transform.localScale.y, transform.localScale.z);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Press the left arrow key to move the RigidBody left
            rb.velocity = new Vector2(-5.0f * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //Press the right arrow key to move the RigidBody right
            rb.velocity = new Vector2(5.0f * Time.deltaTime, 0.0f);
        }
        else
        {
            //Make the character(s) stop
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }
}
