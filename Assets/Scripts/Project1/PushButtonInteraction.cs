using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonInteraction : MonoBehaviour
{
    public UnityEvent onPressButton;
    public ButtonAnimator button;

    public bool pressButton = false;

    //Plays an event and then sets and animation variable to true before invoking the delay function
    public void onPlayerInteract()
    {
        pressButton = true;
        button.pushButton(pressButton);
        onPressButton.Invoke();
        Invoke("delay", 3f);
    }

    //Resets the animation variable after a delay
    private void delay()
    {
        pressButton = false;
        button.pushButton(pressButton);
    }
}
