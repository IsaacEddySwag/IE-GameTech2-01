using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public UnityEvent Pausing;

    //Invokes the pause menu when the button escape is pressed
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Pausing.Invoke();
        }
    }

    public void Pause()
    {
        //Unlocks the players cursor when invoked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Sets the time scale of the game to be 0 pausing all actions in engine
        Time.timeScale = 0;
        //Enables the pause menu on the canvas
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        //Locks the players cursor when invoked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Sets the time scale of the game to be 1 unpausing all actions in engine
        Time.timeScale = 1;
        //Disables the pause menu on the canvas
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        //Loads the main menu scene
        SceneManager.LoadScene("MainMenu");
        //Locks the players cursor when invoked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Sets the time scale of the game to be 1 unpausing all actions in engine
        Time.timeScale = 1;
    }

    public void Quit()
    {
        //Quits out of the application
        Application.Quit();
    }
}
