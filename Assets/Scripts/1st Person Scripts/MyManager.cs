using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MyManager : MonoBehaviour
{
    public static MyManager Instance;
    public int batteryCount = 0;

    public bool interactButton1 = false;
    public bool interactButton2 = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(Instance != this)
        {
            Debug.LogError("More than 1 instance of a manager", this);
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void AddScore(int scoreToAdd)
    {
        batteryCount += scoreToAdd;
    }

    public void canInteract1()
    {
        interactButton1 = true;
    }
    public void canInteract2()
    {
        interactButton2 = true;
    }
}
