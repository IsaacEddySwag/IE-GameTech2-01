using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonInteraction : MonoBehaviour
{
    public UnityEvent onPressButton;

    public void onPlayerInteract()
    {
        Debug.Log("HIT!!!!");
        onPressButton.Invoke();
    }
}
