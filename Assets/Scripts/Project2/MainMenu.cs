using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //When called disable and hide the players cursor then load the level 1 scene
    public void StartGame()
    {
        SceneManager.LoadScene("Project 2");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //When called quits out of the game
    public void Quit()
    {
        Application.Quit();
    }
}
