using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DoorMoveAnimator : MonoBehaviour
{
    private Animator animator;

    //Gets the animator for the attached compontent
    private void Awake()
    { 
        animator = GetComponent<Animator>();
    } 

    //Changes the animator boolean doorOpen when called
    public void doorMove(bool doorUp)
    {
        animator.SetBool("doorOpen", doorUp);
    }

    //Destroys the attached object when called
    public void destroyThis()
    {
        Destroy(this.gameObject);
    }
}
