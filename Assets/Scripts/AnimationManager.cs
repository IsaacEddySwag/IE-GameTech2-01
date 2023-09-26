using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance;
    private Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        animator = GetComponent<Animator>();
    }
    public void pushButton(bool activateAnimation)
    {
        animator.SetBool("isPressed", activateAnimation);
    }

    public void doorMove(bool activateAnimation)
    {
        animator.SetBool("doorOpen", activateAnimation);
    }
}
