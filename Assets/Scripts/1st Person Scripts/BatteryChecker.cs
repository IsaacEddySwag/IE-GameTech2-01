using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BatteryChecker : MonoBehaviour
{
    //3 events for each time the battery count is checked
    public UnityEvent batteryUpdater0;
    public UnityEvent batteryUpdater1;
    public UnityEvent batteryUpdater2;

    public float batteries;

    // Update is called once per frame

    //This update checks for how many batteries the player has.
    //Then activates certain lights if the player has collected that amount of batteries
    void Update()
    {
        batteries = MyManager.Instance.batteryCount;

        switch(batteries)
        {
            case 1:
                batteryUpdater0.Invoke();
                break;
            case 5:
                batteryUpdater1.Invoke();
                break;
            case 8:
                batteryUpdater2.Invoke(); 
                break;
        }
    }
}
