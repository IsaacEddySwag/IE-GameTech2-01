using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DoorSpinAnimator : MonoBehaviour
{
    [SerializeField]private Animator animator;

    //Gets the animator for the attached compontent
    private void Awake()
    { 
        animator = GetComponent<Animator>();
    }

    //Changes the animator boolean spinNow when called
    public void doorSpin(bool nowSpin)
    {
        animator.SetBool("spinNow", nowSpin);
    }
}
