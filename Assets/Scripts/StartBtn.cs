using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public Object goToScene;

    private void OnMouseUp()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(goToScene.name);
    }
}
