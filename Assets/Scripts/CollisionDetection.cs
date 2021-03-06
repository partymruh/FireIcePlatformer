﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CollisionDetection : MonoBehaviour
{
    //Vector2[] vertices = new Vector
    public Vector3 velocity = new Vector3(0, 0, 0);
    public float detectDist;
    public float jumpVel;
    public float grav;
    public float speedFactor;
    public float maxDownVel;

    public GameObject PauseMenu;
    public GameObject OtherMenu;
    public GameObject DeathX;
    private Animator animator;

    private Rigidbody2D rb;
    [SerializeField] private Collider2D coll;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Character's Rigidbody
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Collider2D[] res = new Collider2D[1];   //Set up an array
        rb.GetAttachedColliders(res);           //Get the Rigidbody's collider
        coll = res[0];                          //Set the Collider2D to it
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().path);

        if (PauseMenu != null && OtherMenu != null && Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            PauseMenu.SetActive(true);
            OtherMenu.SetActive(true);
            Time.timeScale = 0;
        }

        //Set up array
        RaycastHit2D[] hits = new RaycastHit2D[10];
        coll.Cast(new Vector2(0, -1), hits, detectDist);    //Cast a ray of the collider toward the ground for detectDist units.
        onGround = false;                       //Set onGround to false. We always want to check IF we are on the ground, and assume we aren't otherwise.
        foreach (RaycastHit2D hit in hits)      //For each index, check if there is something below character.
        {
            if (hit.collider != null && hit.collider.isTrigger == false)
            {
                if (hit.collider.tag == "MovingPlatform")
                {
                    this.transform.parent = hit.collider.transform;
                }
                if (hit.collider.tag == "SplitScreen" || hit.collider.tag == "DamagingObject")
                {
                    Reload();
                }
                if (velocity.y <= 0)
                {
                    velocity.y = 0; //Downward velocity is 0 if touching ground.
                    onGround = true;
                    animator.ResetTrigger("Jumped");
                    animator.SetTrigger("Landed");
                }
            }
        }

        hits = new RaycastHit2D[10];
        coll.Cast(new Vector2(0, 1), hits, detectDist);    //Cast a ray of the collider above for detectDist units.                
        foreach (RaycastHit2D hit in hits)      //For each index, check if there is something above character.
        {
            if (hit.collider != null && hit.collider.isTrigger == false)
            {
                if (velocity.y >= 0)
                {
                    velocity.y = 0;                 //Upward velocity 0 if blocked above.
                }
                if (hit.collider.tag == "SplitScreen" || hit.collider.tag == "DamagingObject")
                {
                    Reload();
                }
            }
        }

        //Left & Right movement. SpeedFactor is a public variable that adjusts speed.
        velocity.x = Input.GetAxis("Horizontal") * speedFactor;

        hits = new RaycastHit2D[10];
        coll.Cast(new Vector2(-1, 0), hits, detectDist);    //Cast a ray of the collider above for detectDist units.                    
        foreach (RaycastHit2D hit in hits)      //For each index, check if there is something left of the character.
        {
            if (hit.collider != null && hit.collider.isTrigger == false)
            {
                if (velocity.x < 0)
                {
                    velocity.x = 0;                 //Left velocity 0 if blocked left.
                }
                if (hit.collider.tag == "SplitScreen" || hit.collider.tag == "DamagingObject")
                {
                    Reload();
                }
            }
        }

        hits = new RaycastHit2D[10];
        coll.Cast(new Vector2(1, 0), hits, detectDist);    //Cast a ray of the collider above for detectDist units.                  
        foreach (RaycastHit2D hit in hits)      //For each index, check if there is something right of the character.
        {
            if (hit.collider != null && hit.collider.isTrigger == false)
            {
                if (velocity.x > 0)
                {
                    velocity.x = 0;                 //Right velocity 0 if blocked right.
                }
                if (hit.collider.tag == "SplitScreen" || hit.collider.tag == "DamagingObject")
                {
                    Reload();
                }
            }
        }

        //If in the air, artifically gravitate downward.
        if (!onGround && velocity.y > maxDownVel)
        {
            velocity.y -= grav * Time.deltaTime;
            if (velocity.y < maxDownVel)
            {
                velocity.y = maxDownVel;
            }
        }

        //If space is pressed and character is on the ground, jump!
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            velocity.y = jumpVel;
            onGround = false;
            animator.ResetTrigger("Landed");
            animator.SetTrigger("Jumped");
        }
        transform.position += velocity * Time.deltaTime;
        if (onGround == false)
        {
            transform.parent = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void Reload()
    {
        if (!GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<HitCheckpoint>().loading)
        {
            Vector3 pos = transform.position;
            GameObject d = Instantiate(DeathX);
            d.transform.position = pos;
            DontDestroyOnLoad(d);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
