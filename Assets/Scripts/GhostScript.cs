using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{

    private GameObject ghost;
    public float alpha;
    public GameObject otherCharacter;
    private float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        //Create the Ghost as a gameObject, and give it it's character's sprite.
        ghost = new GameObject();
        SpriteRenderer ghostrend = ghost.AddComponent<SpriteRenderer>();
        ghostrend.sprite = this.transform.GetComponent<SpriteRenderer>().sprite;

        //Get the sprite's color data, then modify its transparency.
        Color temp = ghostrend.color;
        temp.a = alpha;
        ghostrend.color = temp;

        //Match scale (just in case it is changed!)
        ghost.transform.localScale = this.transform.localScale;

        //Compute the y-offset throughout the level by the spawn locations of both characters (hence why this is determined in the start).
        yOffset = otherCharacter.transform.position.y - this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Update position of the ghost based on the character's location, while accounting for the level-start's y-offset.
        ghost.transform.position = this.transform.position + new Vector3(0, yOffset, 0);
    }
}