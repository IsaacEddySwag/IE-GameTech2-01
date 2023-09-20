using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyManager : MonoBehaviour
{
    public static MyManager Instance;
    public int batteryCount = 0;

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
}
