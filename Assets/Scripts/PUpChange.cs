using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUpChange : MonoBehaviour
{

    public Sprite becomeThisSprite;

    public List<GameObject> affectedTiles;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);

            foreach (GameObject obj in affectedTiles)
            {
                obj.GetComponent<SpriteRenderer>().sprite = becomeThisSprite;
            }
        }
    }
}