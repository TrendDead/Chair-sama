using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCotrol : MonoBehaviour
{
    public GameObject ControlMenu;
    public GameObject StapsMenu;
    public GameObject Menu;


    private bool flagControlMenu;
    private bool flagStapsMenu;
    public bool menu;

    private void Start()
    {
        flagControlMenu = false;
        flagStapsMenu = false;
        menu = true;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.anyKeyDown) if (Input.GetKey(KeyCode.Escape)) ReturnGame();
    }
    public void MenuExit()
    {
        Application.Quit();
    }

    public void OpenCloseControlMenu()
    {
        if (flagControlMenu)
        {
            ControlMenu.SetActive(false);
            flagControlMenu = false;
        }
        else
        {
            ControlMenu.SetActive(true);
            flagControlMenu = true;
        }
    }

    public void ReturnGame()
    {
        if (menu)
        {
            StapsMenu.SetActive(true);
            Menu.SetActive(false);
            menu = false;
            Time.timeScale = 1;
        }
        else
        {
            StapsMenu.SetActive(false);
            Menu.SetActive(true);
            menu = true;
            Time.timeScale = 0;
        }
    }
}
