using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeThrowSpeed : MonoBehaviour
{
    private Animator animator;
    float throwSpeed;

    //Sets the animator of the object to a variable and sets the base speed for the throwing animation
    void Start()
    {
        animator = GetComponent<Animator>();
        throwSpeed = 1;
    }

    //When invokes increases the speed of the throw animation making the player throw snow balls faster
    public void UpgradeThrow(float upgrade)
    {
        throwSpeed += upgrade;

        animator.SetFloat("Speed", throwSpeed);
    }
}
