using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class InteractAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowInteractPrompt(bool showPrompt)
    {
        animator.SetBool("showInteractionPrompt", showPrompt);
    }
}
