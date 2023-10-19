using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayIntro : MonoBehaviour
{
    [SerializeField] private UnityEvent activateCamera;
    [SerializeField] private ThirdPersonCharacterController characterController;
    private bool hasPlayed = false;

    //When the object is triggered
    private void OnTriggerEnter(Collider other)
    {
        //Checks if the player character controller exists and if the cutscene has already played
        if (other.gameObject.GetComponent("ThirdPersonCharacterController") == true && !hasPlayed) 
        {
            //Activates the gamera though a unity event
            activateCamera.Invoke();
            //Disables character controller movement
            characterController.canMove = false;
            //Sets the bool has played to true, making it so the cutscene can't play again
            hasPlayed = true;
        }
    }
}
