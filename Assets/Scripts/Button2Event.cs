using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button2Event : MonoBehaviour
{

    public UnityEvent OnButtonTouch2;
    public UnityEvent TurnOnLight;

    public bool beenTouch = false;
    public int batteries = 0;

    private void Update()
    {
        batteries = GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount;

        if(batteries >= 5)
        {
            TurnOnLight.Invoke();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (beenTouch != true && other.gameObject.name == "Player" && batteries == 5)
        {
            OnButtonTouch2.Invoke();
            beenTouch = true;
        }
    }
}