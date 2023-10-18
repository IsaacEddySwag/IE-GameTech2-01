using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateArm : MonoBehaviour
{
    private Animator animator;
    private ThirdPersonCharacterController characterController;
    public void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GameObject.Find("3rd Person Player").GetComponent<ThirdPersonCharacterController>();
    }
    public void armMove(bool swing)
    {
        animator.SetBool("SwingR", swing);
    }

    public void stopMove()
    {
        animator.SetBool("SwingR", false);
    }

    public void Throw()
    {
        characterController.ThrowBall();
    }
}
