using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    public GameObject platform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            platform.GetComponent<Oscillate>().SetActive(true);
        }
    }
}
