using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ButtonAnimator : MonoBehaviour
{
    private Animator animator;

    //Gets the animator of the compntent
    private void Awake()
    { 
        animator = GetComponent<Animator>();
    }

    //When function is called sets the animator bool is pressed to true
    public void pushButton(bool isPressed)
    {
        animator.SetBool("isPressed", isPressed);
    }
}
