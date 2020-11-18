using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUpSFX : MonoBehaviour
{
    public GameObject audioEnvironment;
    public AudioClip collectClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioEnvironment.GetComponent<AudioSource>().PlayOneShot(collectClip);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
