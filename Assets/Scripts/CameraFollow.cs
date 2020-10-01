using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject character;
    public float top, bottom, right, left, maxCamSpeed;
    //private bool restState;  //Perhaps we will use this later if our camera becomes more advanced.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != character.transform.position)
        {
            Vector3 nextPosition = Vector3.Lerp(transform.position, character.transform.position, maxCamSpeed);
            nextPosition.z = -10;
            transform.position = nextPosition;
        } 
    }
}
