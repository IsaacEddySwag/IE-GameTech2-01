using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeBatteryCount : MonoBehaviour
{
    public int batteryCount = 0;
    public TextMeshProUGUI batteryCountUI;

    // Update is called once per frame
    //Gets the battery count from the gamemanager
    //Then calls the change text function
    void Update()
    {
        batteryCount = GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount;
        ChangeText();
    }

    //Updates the battery count UI element to be the current amount of batteries collected
    public void ChangeText()
    {
        batteryCountUI.text = batteryCount.ToString();
    }
}
