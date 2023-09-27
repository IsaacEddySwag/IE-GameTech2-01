using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
        GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount = 0;
        GameObject.Find("GameManager").GetComponent<MyManager>().interactButton1 = false;
        GameObject.Find("GameManager").GetComponent<MyManager>().interactButton2 = false;
    }
}
