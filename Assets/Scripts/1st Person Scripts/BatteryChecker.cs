using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatteryChecker : MonoBehaviour
{
    public UnityEvent batteryUpdater0;
    public UnityEvent batteryUpdater1;
    public UnityEvent batteryUpdater2;

    public float batteries;

    // Update is called once per frame
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
