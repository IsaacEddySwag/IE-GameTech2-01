using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

//Code requires the type of component specified and will create one if one isn't present
[RequireComponent(typeof(CharacterController))]

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public InputActionAsset CharacterActionAsset;

    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction sprintAction;

    private CharacterController characterController;
    public Camera FirstPersonCamera;

    private Vector2 moveValue;
    private Vector2 rotateValue;

    private Vector3 currentRotationAngle;

    private void OnEnable()
    {
        //Enables the gameplay control scheme from an input action map
        CharacterActionAsset.FindActionMap("Gameplay").Enable();
    }

    private void OnDisable()
    {
        //Disables the gameplay control scheme from an input action map
        CharacterActionAsset.FindActionMap("Gameplay").Disable();
    }

    void Awake()
    {
        //Gets the character control component from the object
        characterController = GetComponent<CharacterController>();

        //Sets the moveAction and rotateAction as the set action map functions
        moveAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Move");
        rotateAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Rotation");
        sprintAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Sprint");



        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMove();
        ProcessCamera();
    }

    private void ProcessMove()
    {
        Vector3 moveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;
        moveDirection.y = 0;
        moveValue = moveAction.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;

        characterController.Move(moveDirection);
    }

    private void ProcessCamera()
    {
        //Sets moveValue to read the inputs and translates it into an x and y value in a Vector2
        rotateValue = rotateAction.ReadValue<Vector2>() * Time.deltaTime * 2500;

        currentRotationAngle = new Vector3(currentRotationAngle.x - rotateValue.y, currentRotationAngle.y + rotateValue.x, 0);

        currentRotationAngle = new Vector3(Mathf.Clamp(currentRotationAngle.x, -85, 85), currentRotationAngle.y, currentRotationAngle.z);

        FirstPersonCamera.transform.rotation = Quaternion.Euler(currentRotationAngle);
    }
    private void ProcessSprint()
    {
        if (sprintAction.IsPressed())
        {
            moveSpeed = (moveSpeed + 0.1f) * Time.deltaTime;
        }
        else
        {
            moveSpeed = (moveSpeed - 0.1f) * Time.deltaTime;
        }
    }

    private void ProcessVerticalMovement()
    {

    }

    //Triggers only in the unity editor
    void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
