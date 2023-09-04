using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

//Code requires the type of component specified and will create one if one isn't present
[RequireComponent(typeof(CharacterController))]

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxSpeed = 12f;
    public float baseSpeed = 5f;
    public float maxJump = 0f;
    private float vertMove = 0f;

    public float basePov;

    public InputActionAsset CharacterActionAsset;

    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    private CharacterController characterController;
    public Camera FirstPersonCamera;

    private bool isSprinting = false;
    public bool isJumping = false;
    private bool doubleActive = true;

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
        jumpAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Jump");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        basePov = FirstPersonCamera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        isSprinting = sprintAction.IsPressed();

        ProcessMove();
        ProcessCamera();
    }

    private void ProcessMove()
    { 
        if (sprintAction.IsPressed())
        {
            FirstPersonCamera.fieldOfView = basePov + 20;
            moveSpeed = maxSpeed;
        }
        else if (!sprintAction.IsPressed())
        {
            FirstPersonCamera.fieldOfView = basePov;
            moveSpeed = baseSpeed;
        }

        moveValue = moveAction.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;
        Vector3 moveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;
        moveDirection.y = 0;
        moveDirection.y = vertMove;

        ProcessVerticalMovement();

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

    private void ProcessVerticalMovement()
    {
        if(characterController.isGrounded) 
        {
            doubleActive = true;
        }

        if (characterController.isGrounded && vertMove < 0)
        {
            isJumping = false;
            vertMove = 0;
        }

        bool jumpButtonDown = jumpAction.triggered && jumpAction.ReadValue<float>() > 0;

        if (jumpButtonDown && (characterController.isGrounded || doubleActive))
        {
            vertMove += Mathf.Sqrt(maxJump * -2.0f * Physics.gravity.y);
            doubleActive = false;
            isJumping = true;
        }

        vertMove += Physics.gravity.y * Time.deltaTime;

        characterController.Move(Vector3.up * vertMove * Time.deltaTime);
    }

    //Triggers only in the unity editor
    void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
