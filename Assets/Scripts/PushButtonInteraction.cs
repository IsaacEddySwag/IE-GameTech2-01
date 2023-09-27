using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonInteraction : MonoBehaviour
{
    public UnityEvent onPressButton;
    public ButtonAnimator button;

    public bool pressButton = false;
    public void onPlayerInteract()
    {
        pressButton = true;
        button.pushButton(pressButton);
        onPressButton.Invoke();
        Invoke("delay", 5f);
    }

    private void delay()
    {
        pressButton = false;
        button.pushButton(pressButton);
    }
}
