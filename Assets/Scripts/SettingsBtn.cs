using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBtn : MonoBehaviour
{
    public GameObject settingsMenu, mainMenu;

    private void OnMouseUp()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
