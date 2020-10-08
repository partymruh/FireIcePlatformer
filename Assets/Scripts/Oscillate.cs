using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    public bool toPointA;
    public Vector2 a, b;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if(toPointA)
        {
            transform.position = Vector2.MoveTowards(transform.position, a, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, a) < 5)
            {
                toPointA = false;
            }
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, b, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, b) < 5)
            {
                toPointA = true;
            }
        }
    }
}
