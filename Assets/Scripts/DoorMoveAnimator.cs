using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DoorMoveAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    { 
        animator = GetComponent<Animator>();
    } 
    public void doorMove(bool doorUp)
    {
        animator.SetBool("doorOpen", doorUp);
    }

    public void destroyThis()
    {
        Destroy(this.gameObject);
    }
}
