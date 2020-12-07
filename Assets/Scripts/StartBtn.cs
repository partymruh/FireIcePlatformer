using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    [SerializeField]
    public string scenePath;

    private void OnMouseUp()
    {
        Time.timeScale = 1;

        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("DeathX");

        for (int i = 0; i < toDestroy.Length; i++)
        {
            Destroy(toDestroy[i]);
        }

        SceneManager.LoadScene(scenePath);  
    }
}
