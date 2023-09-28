using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeBatteryCount : MonoBehaviour
{
    public int batteryCount = 0;
    public TextMeshProUGUI batteryCountUI;

    // Update is called once per frame
    void Update()
    {
        batteryCount = GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount;
        ChangeText();
    }

    public void ChangeText()
    {
        batteryCountUI.text = batteryCount.ToString();
    }
}
