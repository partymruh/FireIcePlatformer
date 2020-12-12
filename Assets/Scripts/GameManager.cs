using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource[] playlist;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine("PlayList");
    }

    private IEnumerator PlayList()
    {
        while(true)
        {
            double duration = 0;
            double totDuration = 0;
            for (int i = 0; i < playlist.Length; i++)
            {
                playlist[i].PlayScheduled(AudioSettings.dspTime + totDuration + 1.5);
                duration = (double)playlist[i].clip.samples / playlist[i].clip.frequency;
                totDuration += duration;
            }
            yield return new WaitForSeconds((float)totDuration);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
