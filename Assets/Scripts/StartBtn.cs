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
        SceneManager.LoadScene(scenePath);  
    }
}
