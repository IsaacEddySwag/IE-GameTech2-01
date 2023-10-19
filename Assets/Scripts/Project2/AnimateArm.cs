using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateArm : MonoBehaviour
{
    private Animator animator;
    private ThirdPersonCharacterController characterController;
    public void Awake()
    {
        //Gets the animator of the object the scripts attached too and sets it to a variable
        animator = GetComponent<Animator>();
        //Gets the character controller from the player character and sets it to a variable.
        characterController = GameObject.Find("3rd Person Player").GetComponent<ThirdPersonCharacterController>();
    }

    //Function sets the arm swing animator bool to be equal to the bool passed
    public void armMove(bool swing)
    {
        animator.SetBool("SwingR", swing);
    }

    //Function sets the arm swing animator bool to be equal to false
    public void stopMove()
    {
        animator.SetBool("SwingR", false);
    }

    //Function refrences the throwball function on the character controller script. Function spawns a moving snowball.
    public void Throw()
    {
        characterController.ThrowBall();
    }
}
