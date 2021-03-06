﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitCheckpoint : MonoBehaviour
{
    [SerializeField]
    public string scenePath;

    public GameObject levelWinText;

    private float timer;
    public bool loading = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loading)
        {
            if (Time.realtimeSinceStartup - timer > 2f)
            {
                GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("DeathX");

                for (int i = 0; i < toDestroy.Length; i++)
                {
                    Destroy(toDestroy[i]);
                }

                if (GameObject.Find("GameManager") != null)
                {
                    GameObject.Find("GameManager").GetComponent<LevelWinTracker>().beatenLevels.Add(SceneManager.GetActiveScene().path);
                }

                Time.timeScale = 1;
                SceneManager.LoadScene(scenePath);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Instantiate(levelWinText);

            loading = true;
            Time.timeScale = 0;
            timer = Time.realtimeSinceStartup;
        }
    }
}
