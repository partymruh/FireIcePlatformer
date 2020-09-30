using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Collision : MonoBehaviour
{
    //Vector2[] vertices = new Vector
    public Vector3 velocity = new Vector3(0, 0, 0);
    public float detectDist;
    public float jumpVel;
    public float grav;
    public float speedFactor;
    public float maxDownVel;

    private Rigidbody2D rb;
    private Collider2D coll;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Character's Rigidbody
        rb = GetComponent<Rigidbody2D>();
        Collider2D[] res = new Collider2D[1];   //Set up an array
        rb.GetAttachedColliders(res);           //Get the Rigidbody's collider
        coll = res[0];                          //Set the Collider2D to it
    }

    // Update is called once per frame
    void Update()
    {
        //Set up array
        RaycastHit2D[] hits = new RaycastHit2D[10];
        coll.Cast(new Vector2(0, -1), hits, detectDist);    //Cast a ray of the collider toward the ground for detectDist units.
        onGround = false;                       //Set onGround to false. We always want to check IF we are on the ground, and assume we aren't otherwise.
        foreach (RaycastHit2D hit in hits)      //For each index, check if there is something below character.
        {
            if (hit.collider != null)
            {

                velocity.y = 0;                 //Downward velocity is 0 if touching ground.
                onGround = true;
            }
        }

        hits = new RaycastHit2D[10];
        coll.Cast(new Vector2(0, 1), hits, detectDist);    //Cast a ray of the collider above for detectDist units.                
        foreach (RaycastHit2D hit in hits)      //For each index, check if there is something above character.
        {
            if (hit.collider != null)
            {
                if (velocity.y > 0)
                {
                    velocity.y = 0;                 //Upward velocity 0 if blocked above.
                }
            }
        }


        //Left & Right movement since I couldn't find the supposed "other script". .05f is a controlling factor for speed.
        velocity.x = Input.GetAxis("Horizontal") * speedFactor;

        hits = new RaycastHit2D[10];
        coll.Cast(new Vector2(-1, 0), hits, detectDist);    //Cast a ray of the collider above for detectDist units.                    
        foreach (RaycastHit2D hit in hits)      //For each index, check if there is something above character.
        {
            if (hit.collider != null)
            {
                if (velocity.x < 0)
                {
                    velocity.x = 0;                 //Upward velocity 0 if blocked above.
                }
            }
        }

        hits = new RaycastHit2D[10];
        coll.Cast(new Vector2(1, 0), hits, detectDist);    //Cast a ray of the collider above for detectDist units.                  
        foreach (RaycastHit2D hit in hits)      //For each index, check if there is something above character.
        {
            if (hit.collider != null)
            {
                if (velocity.x > 0)
                {
                    velocity.x = 0;                 //Upward velocity 0 if blocked above.
                }
            }
        }

        //If in the air, artifically gravitate downward.
        if (!onGround && velocity.y > maxDownVel)
        {
            velocity.y -= grav;
            if (velocity.y < maxDownVel)
            {
                velocity.y = maxDownVel;
            }
        }

        //If space is pressed and character is on the ground, jump!
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            velocity.y += jumpVel;
            onGround = false;
        }

        transform.position += velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
