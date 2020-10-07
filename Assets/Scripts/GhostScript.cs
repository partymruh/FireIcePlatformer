using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{

    GameObject ghost;
    public float alpha;
    public Vector3 ghostOffset;

    // Start is called before the first frame update
    void Start()
    {
        ghost = new GameObject();
        SpriteRenderer ghostrend = ghost.AddComponent<SpriteRenderer>();
        ghostrend.sprite = this.transform.GetComponent<SpriteRenderer>().sprite;

        Color temp = ghostrend.color;
        temp.a = alpha;
        ghostrend.color = temp;
        ghost.transform.localScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        ghost.transform.position = this.transform.position + ghostOffset;
    }
}
