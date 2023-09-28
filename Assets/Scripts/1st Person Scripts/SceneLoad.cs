using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string sceneName;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount = 0;
        GameObject.Find("GameManager").GetComponent<MyManager>().interactButton1 = false;
        GameObject.Find("GameManager").GetComponent<MyManager>().interactButton2 = false;
    }
}
