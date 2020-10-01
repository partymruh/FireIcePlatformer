using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSplit : MonoBehaviour
{
    public GameObject firePlayer, icePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float halfX = (firePlayer.transform.position.x + icePlayer.transform.position.x) / 2;
        transform.position = new Vector2(halfX, transform.position.y);
    }
}
