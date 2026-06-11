using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject menuPanel;
    //public GameObject openPanel;

    public void OpenMinu()
    {
        ToggleMenu();
    }

    public void CloseMenu()
    {
        ToggleMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        bool isOpen = menuPanel.activeSelf;
        menuPanel.SetActive(isOpen = !isOpen);

        if (isOpen)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }
}
