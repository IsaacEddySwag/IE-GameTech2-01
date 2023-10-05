using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.Events;

public class PlayIntro : MonoBehaviour
{
    [SerializeField] private UnityEvent activateCamera;
    [SerializeField] private ThirdPersonCharacterController characterController;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent("ThirdPersonCharacterController") == true && !hasPlayed) 
        {
            activateCamera.Invoke();
            characterController.canMove = false;
            hasPlayed = true;
        }
    }
}
