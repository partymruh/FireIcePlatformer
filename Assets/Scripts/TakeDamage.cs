﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SplitScreen")
        {
            Debug.Log("Ouch! Don't touch the rift!");
        }
        if (collision.tag == "DamagingObject")
        {
            Debug.Log("Ouch!");
        }
    }
}