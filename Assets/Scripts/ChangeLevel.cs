using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string sceneName;
    public bool canChangeLevel = true;

    private void OnMouseUp()
    {
        if(canChangeLevel)
            SceneManager.LoadScene(sceneName);
    }
}
