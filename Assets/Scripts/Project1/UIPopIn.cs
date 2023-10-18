using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIPopIn : MonoBehaviour
{
    private float batteryCount = 0;
    private Animator animator;

    //Gets the animator for the attached compontent
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
     if (GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount > batteryCount)
        {
            UISlideIn(true);
            Invoke("delay", 2f);
        }

        batteryCount = GameObject.Find("GameManager").GetComponent<MyManager>().batteryCount;
    }

    public void UISlideIn(bool slideIn)
    {
        animator.SetBool("UISlideIn", slideIn);
    }

    private void delay()
    {
        bool slideIn = false;
        animator.SetBool("UISlideIn", slideIn);
    }
}
