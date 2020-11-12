using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    public GameObject platform;

    private void OnDestroy()
    {
        if(platform)
            platform.GetComponent<Oscillate>().SetActive(true);
    }
}
