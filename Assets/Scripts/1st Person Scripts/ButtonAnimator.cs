using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ButtonAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    { 
        animator = GetComponent<Animator>();
    }
    public void pushButton(bool isPressed)
    {
        animator.SetBool("isPressed", isPressed);
    }
}
