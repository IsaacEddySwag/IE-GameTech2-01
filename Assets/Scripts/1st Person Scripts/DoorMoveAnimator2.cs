using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DoorMoveAnimator2 : MonoBehaviour
{
    private Animator animator;

    //Gets the animator for the attached compontent
    private void Awake()
    { 
        animator = GetComponent<Animator>();
    }

    //Changes the animator boolean FinalDoorMove when called
    public void doorMove(bool doorUp)
    {
        animator.SetBool("FinalDoorMove", doorUp);
    }
}
