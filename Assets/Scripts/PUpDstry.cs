using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUpDstry : MonoBehaviour
{
    //public GameObject powerupTarget;
    public List<GameObject> affectedTiles;
    public float delay;
    public GameObject particle;

    public Color fireColor;
    public Color iceColor;
    public bool ColorStartsAsFire;

    private bool active;
    private GameObject part;
    private float maxDelay;

    private Vector3 destination;

    private ParticleSystem.MainModule particleSettings;

    private void Start()
    {
        maxDelay = delay;

        foreach (GameObject tile in affectedTiles)
        {
            destination += tile.transform.position;
        }

        destination /= affectedTiles.Count;
    }
    //Add the powerup to the level, attach this script to it.
    //Then attach any individual blocks that should be destroyed when this powerup is touched to "affectedTiles" in the Engine.

    private void FixedUpdate()
    {
        if (active)
        {
            if (delay > 0)
            {
                part.transform.position = Vector3.Lerp(transform.position, destination, (maxDelay - delay) / maxDelay);

                particleSettings.startColor = Color.Lerp(fireColor, iceColor, ((ColorStartsAsFire ? 1f : 0f) * maxDelay + (-1f * (ColorStartsAsFire ? 1f : -1f)) * delay) / maxDelay);

                delay--;
            }

            if (delay == 0)
            {
                Destroy(part);
                foreach (GameObject obj in affectedTiles)
                {
                    Destroy(obj);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = true;

            Color c = gameObject.GetComponent<SpriteRenderer>().color;
            c.a = 0;
            gameObject.GetComponent<SpriteRenderer>().color = c;

            if (part == null)
            {
                part = Object.Instantiate<GameObject>(particle);
                particleSettings = part.GetComponent<ParticleSystem>().main;

                if (ColorStartsAsFire)
                {
                    particleSettings.startColor = fireColor;
                }
                else
                {
                    particleSettings.startColor = iceColor;
                }
            }
            part.transform.position = transform.position;
            part.SetActive(true);
        }
    }
}
