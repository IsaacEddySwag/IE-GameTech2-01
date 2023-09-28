using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatteryEvent : MonoBehaviour
{
    public UnityEvent playSound;
    public void OnTriggerEnter(Collider other)
    {
        MyManager.Instance.AddScore(1);
        Destroy(this.gameObject);
    }
}
