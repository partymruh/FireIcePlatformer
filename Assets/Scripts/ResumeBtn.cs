using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseMenu;
    public GameObject OtherMenu;

    private void OnMouseUp()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        OtherMenu.SetActive(false);
    }
}
