using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DoorSpinAnimator : MonoBehaviour
{
    [SerializeField]private Animator animator;

    private void Awake()
    { 
        animator = GetComponent<Animator>();
    }
    public void doorSpin(bool nowSpin)
    {
        animator.SetBool("spinNow", nowSpin);
    }
}
