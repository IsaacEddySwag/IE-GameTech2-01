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

    public float basePov = 60;
    public float maxPov = 80;

    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;

    public InputActionAsset CharacterActionAsset;

    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    private CharacterController characterController;
    public Camera FirstPersonCamera;

    public bool isSprinting = false;
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

        //Disables cursor visability
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Calls both player and camera movement functions
        ProcessMove();
        ProcessCamera();
    }

    private void ProcessMove()
    { 
        //Checks if the player is sprinting, if so makes player faster and increase FOV
        if (sprintAction.IsPressed())
        {
            FirstPersonCamera.fieldOfView = Mathf.Lerp(FirstPersonCamera.fieldOfView, maxPov, 10f * Time.deltaTime);
            isSprinting = true;
            moveSpeed = maxSpeed;
        }

        //If player isnt sprinting set speed and FOV back to normal
        else if (!sprintAction.IsPressed() && isSprinting == true)
        {
            FirstPersonCamera.fieldOfView = Mathf.Lerp(FirstPersonCamera.fieldOfView, basePov, 1.5f * Time.deltaTime); 
            moveSpeed = baseSpeed;
            if(FirstPersonCamera.fieldOfView <= 60)
            {
                isSprinting = false;
            }
        }


        //Clamps the field of view to to the base and max pov
        FirstPersonCamera.fieldOfView = Mathf.Clamp(FirstPersonCamera.fieldOfView, basePov, maxPov);


        //Adds force to the player in vertical and horizontal positions based on player input
        moveValue = moveAction.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;
        Vector3 moveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;

        ProcessVerticalMovement();

        moveDirection.y = vertMove * Time.deltaTime;

        characterController.Move(moveDirection);
    }

    private void ProcessCamera()
    {
        float rotationX = rotateValue.y * sensitivityY;
        float rotationY = rotateValue.x * sensitivityX;

        //Sets moveValue to read the inputs and translates it into an x and y value in a Vector2
        rotateValue = rotateAction.ReadValue<Vector2>() * Time.deltaTime;


        //Code finds the locations of the players camera rotation and keeps it in bounds finally affects camera rotation
        currentRotationAngle = new Vector3(currentRotationAngle.x - rotationX, currentRotationAngle.y + rotationY, 0);

        currentRotationAngle = new Vector3(Mathf.Clamp(currentRotationAngle.x, -85, 85), currentRotationAngle.y, currentRotationAngle.z);

        FirstPersonCamera.transform.rotation = Quaternion.Euler(currentRotationAngle);
    }

    private void ProcessVerticalMovement()
    {
        //checks if the player is grounded and sets variables
        if(characterController.isGrounded) 
        {
            doubleActive = true;
            isJumping = false;
        }

        //Changes player y position if their movement is negative and theyre grounded
        if (characterController.isGrounded && vertMove < 0)
        {
            vertMove = 0;
        }
        
        //Checks if the jumpaction button is triggered
        bool jumpButtonDown = jumpAction.triggered && jumpAction.ReadValue<float>() > 0;

        //If jumpaction is triggered apply force the makes the player jump
        if (jumpButtonDown && (characterController.isGrounded || doubleActive))
        {
            vertMove += Mathf.Sqrt(maxJump * -2.0f * Physics.gravity.y);
            doubleActive = false;
            isJumping = true;
        }

        //Adds gravity to player character
        vertMove += Physics.gravity.y * Time.deltaTime;
    }

    //Triggers only in the unity editor
    void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
