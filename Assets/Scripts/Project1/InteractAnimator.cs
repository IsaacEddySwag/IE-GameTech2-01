using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class InteractAnimator : MonoBehaviour
{
    private Animator animator;

    //Gets the animator for the attached compontent
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    //Changes the animator boolean showInteractionPrompt when called
    public void ShowInteractPrompt(bool showPrompt)
    {
        animator.SetBool("showInteractionPrompt", showPrompt);
    }
}
