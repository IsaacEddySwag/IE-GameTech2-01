using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonInteraction1 : MonoBehaviour
{
    public UnityEvent onPressButton;
    public float batteryCount = 0f;

    public bool interactButton1 = false;

    private void Update()
    {
        //Keeps updating battery count to be the current batteries the player has collected
        batteryCount = GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount;
        interactButton1 = GameObject.Find("GameManager").GetComponent<MyManager>().interactButton1;
    }

    public void onPlayerInteract()
    {
        //Activates event after 5 batteries have been collected
        Debug.Log("HIT!!!!");

        if (batteryCount >= 1f)
        {
            onPressButton.Invoke();
        }
        else if (batteryCount >= 5f && interactButton1 == true)
        {
            onPressButton.Invoke();
        }
    }
}
