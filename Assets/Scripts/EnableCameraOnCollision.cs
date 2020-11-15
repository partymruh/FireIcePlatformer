using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCameraOnCollision : MonoBehaviour
{
    public CinemachineVirtualCamera myCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (myCamera)
            {
                myCamera.enabled = true;
            } else
            {
                Debug.LogError("You did not assign a virtual camera to this script.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            myCamera.enabled = false;
        }
    }
}
