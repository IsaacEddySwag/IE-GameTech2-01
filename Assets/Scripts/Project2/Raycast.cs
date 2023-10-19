using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{
    public InputActionAsset characterInputActions;
    public InputAction interactAction;

    public Camera playerCamera;
    public float distance = 2f;

    RaycastHit interactionHitInfo;

    public Vector3 hit;



    private void Awake()
    {
        characterInputActions.FindActionMap("Gameplay").Enable();
        interactAction = characterInputActions.FindActionMap("Gameplay").FindAction("Attack");
    }

    private void OnEnable()
    {
        //Enables the gameplay control scheme from an input action map
        characterInputActions.FindActionMap("Gameplay").Enable();
    }

    private void OnDisable()
    {
        //Disables the gameplay control scheme from an input action map
        characterInputActions.FindActionMap("Gameplay").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Convert vehicle 'local space' forward into 'world space' forward.
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        //Shoots out a raycast that hits objects based on the camera view
        bool interactInputPressed = interactAction.triggered && interactAction.ReadValue<float>() > 0;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);


        //Checks if the player hits an object tagged as interactable and actiavtes a UI element
        hit = ray.GetPoint(distance);
    }

    public void UpgradeDistance(float upgrade)
    {
        distance += upgrade;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward);
    }
}
