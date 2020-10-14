using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUpDstry : MonoBehaviour
{
    //public GameObject powerupTarget;
    public List<GameObject> affectedTiles;

    //Add the powerup to the level, attach this script to it.
    //Then attach any individual blocks that should be destroyed when this powerup is touched to "affectedTiles" in the Engine.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            foreach (GameObject obj in affectedTiles)
            {
                Destroy(obj);
            }
        }
    }
}
