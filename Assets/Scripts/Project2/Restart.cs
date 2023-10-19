using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //Checks if the object with tag player hits its trigger, if so then it resets the current level to is intial state
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Project 2");
        }
    }
}
