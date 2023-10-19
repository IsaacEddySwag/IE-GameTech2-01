using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string sceneName;

    //Loads a scene and sets 
    public void LoadScene(string name)
    {
        //Sets game manager variables to the default and reloads the scene
        GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount = 0;
        GameObject.Find("GameManager").GetComponent<MyManager>().interactButton1 = false;
        GameObject.Find("GameManager").GetComponent<MyManager>().interactButton2 = false;
        SceneManager.LoadScene(name);
    }
}
