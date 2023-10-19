using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

[RequireComponent(typeof(CharacterController))]

public class ThirdPersonCharacterController : MonoBehaviour
{
    public AnimateArm animateArm; 
    public HealthBar healthBar;

    public float maxSpeed = 3f;
    public float moveAcceleration = 6f;

    public Camera playerCamera;

    public float jumpSpeed = 5f;
    public float jumpMaxTime = 0.5f;
    public float jumpTimer = 0f;

    public float playerMaxHealth = 100f;
    public float playerHealth;

    private CharacterController characterController;
    private Animator animator;

    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public Transform bulletSpawn;
    public Animator lowHealthAnimator;

    private Vector2 moveInput = Vector2.zero;
    private Vector2 currentHorizontalVelocity = Vector2.zero;
    private float currentVerticalVelocity;

    private bool jumpInputPressed;
    private bool isJumping;
    public bool canMove = true;

    private void Awake()
    {
        //Sets the AnimateArm script on the RArmPivot to a variable and then sets the animator and character controller to variables as well
        animateArm = GameObject.Find("RArmPivot").GetComponent<AnimateArm>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        //Gets the bullet spawn point object on the player character
        bulletSpawnPoint = GameObject.Find("BulletSpawnR");

        //Locks and disables the players cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Sets the player health to be the max health of the player
        playerHealth = playerMaxHealth;
        //Updates the health bar to reflect they player being at max health
        healthBar.SetMaxHealth(playerMaxHealth);
    }

    private void Update()
    {
        //Checks if the player can move, if not disables player and camera movement
        if(canMove)
        {
            Movement();
            CameraMovement();
        }

        //Gets the transform of the bullet spawn point and sets it to bulletSpawn
        bulletSpawn = bulletSpawnPoint.transform;

        //Invokes the death function on the player which resets the level when health point equal zero
        Death();

        //Resets the player health to be equal to max health if the player health goes over
        if(playerHealth > playerMaxHealth) 
        {
            playerHealth = playerMaxHealth;
        }
    }

    public void Movement()
    {
        //Checks if the player isn't jumping
        if (!isJumping)
        {
            //Adds gravity pushing the player down
            currentVerticalVelocity += Physics.gravity.y * Time.deltaTime;

            if (characterController.isGrounded && currentVerticalVelocity < 0)
            {
                //Adds gravity pushing the player down
                currentVerticalVelocity = Physics.gravity.y * Time.deltaTime;
            }
        }
        else
        {
           //If the player is jumping add time delta time to the jumptimer
            jumpTimer += Time.deltaTime;

            //Once jump timer hits the max jump time the player is no longer jumping and gravity takes effect
            if (jumpTimer >= jumpMaxTime)
            {
                isJumping = false;
            }
        }

        //creates a new vector 3 thats set to the current vector 3 of the player
        Vector3 currentVelocity = new Vector3(currentHorizontalVelocity.x, currentVerticalVelocity, currentHorizontalVelocity.y);

        //Creates a new vector 3 that changes the y scale on the previous vector 3 to zero but everything else is the same
        Vector3 horizontalDirection = Vector3.Scale(currentVelocity, new Vector3(1, 0, 1));
        //If the magnitude of the previous vector 3
        if (horizontalDirection.magnitude > 0.0001)
        {
            //Creates a new quartenion the gets the vector 3 horizontal direction and normalizes its values
            Quaternion newDirection = Quaternion.LookRotation(horizontalDirection.normalized);
            //Moves from the current rotation of the character controller towards the new quarternion by delta time times move acceleration
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * moveAcceleration);
        }

        //Adds the current velocity to the character controller making it move when kets are pressed
        characterController.Move(currentVelocity * Time.deltaTime);
    }

    public void CameraMovement()
    {
        //Creates a new vector 3 that is equal to the x and z of move input
        Vector3 cameraSpaceMovement = new Vector3(moveInput.x, 0, moveInput.y);
        //sets previous vector 3 to be equal to the transform direction of the camera based on its previously gotten vector 3 inputs
        cameraSpaceMovement = playerCamera.transform.TransformDirection(cameraSpaceMovement);

        //Creates a vector 2 out of the previous vector 3 only using the x and z of that vector 3
        Vector2 cameraHorizontalMovement = new Vector2(cameraSpaceMovement.x, cameraSpaceMovement.z);

        //Seys the current horizontal velocity equal to a lerp between the current camera position towards the vector 2 of the camera based on the variable max speed
        currentHorizontalVelocity = Vector2.Lerp(currentHorizontalVelocity, cameraHorizontalMovement * maxSpeed, Time.deltaTime * moveAcceleration);
    }
    
    //Gets the value of the player movement controls, checking to see if the player is inputing on the controller for movement
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); 
    }

    public void OnJump(InputValue value) 
    {
        //Gets the value of the pressedjump input of the player if its greater then 0(no input)
        jumpInputPressed = value.Get<float>() > 0f;
        //Checks if the jump input is pressed
        if(jumpInputPressed) 
        {
            //Checks if the player is grounded
            if(characterController.isGrounded) 
            {
                //Sets is jumping to true
                isJumping = true;
                //Sets the jump time to 0
                jumpTimer = 0;
                //Sets the vertical velocity to be equal to the jumpSpeed;
                currentVerticalVelocity = jumpSpeed;
            }
        }
        else
        {
            //Checks if isjumping is true
            if(isJumping) 
            {
                //Sets is jumping to false
                isJumping = false;
            }
        }
    }

    //If player can move and inputs the attack button then the animate arm bool arm move is set to true making the player throw a snowball
    public void OnAttack(InputValue value)
    {
        if (canMove)
        {
            animateArm.armMove(true);
        }
    }

    public void ThrowBall()
    {
        //sets the variable game object equal to a prefab of the bullet
        GameObject bulletCopy = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        //Invokes the shoot function of the script bullets on the bullet making the bullet fire
        bulletCopy.GetComponent<Bullets>().Shoot();
    }

    public void Death()
    {
        //Checks if player health is equal to or less then 0
        if (playerHealth <= 0)
        {
            //If ture reloads scene
            SceneManager.LoadScene("Project 2");
        }
        //Checks if player health is equal to or less then players max health divided by 5
        else if (playerHealth <= playerMaxHealth / 5) 
        {
            //Activates the low health indicator by setting the lowhealth bool of the animator lowhealthanimator to be true
            lowHealthAnimator.SetBool("LowHealth", true);
        }
        else
        {
            //Deactivates the low health indicator by setting the lowhealth bool of the animator lowhealthanimator to be false when health is above the other numbers
            lowHealthAnimator.SetBool("LowHealth", false);
        }
    }

    //When players hit removes damage from health and sets the healthbar to show damage, also fades health bar to show player their current health
    public void IsHit(float damage)
    {
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
        healthBar.FadeIn();
    }

    //Increases max speed when invoked
    public void UpgradeSpeed(float upgrade)
    {
        maxSpeed += upgrade;
        moveAcceleration += upgrade;
    }

    //Increases max jump when invoked
    public void UpgradeJump(float upgrade)
    {
        jumpSpeed += upgrade;
        jumpMaxTime += upgrade;
    }

    //Increases max health when invoked
    public void UpgradeHealth(int upgrade)
    {
        playerHealth += upgrade;
        playerMaxHealth += upgrade;
    }

    //When invokes allows player to move
    public void willItMove(bool willMove)
    {
        canMove = willMove;
    }
}
