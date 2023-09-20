using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button1Interaction : MonoBehaviour
{

    public UnityEvent OnButtonTouch;

    public bool beenTouch = false;
    public int batteries = 0;

    private void Update()
    {
        batteries = GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (beenTouch != true && other.gameObject.name == "Player" && batteries == 1) 
        {
            OnButtonTouch.Invoke();
            beenTouch = true;
        }
    }
}
