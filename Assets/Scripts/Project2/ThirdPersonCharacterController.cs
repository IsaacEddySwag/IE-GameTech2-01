using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
        animateArm = GameObject.Find("RArmPivot").GetComponent<AnimateArm>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        healthBar.SetMaxHealth(playerMaxHealth);
        playerHealth = playerMaxHealth;
    }

    private void Update()
    {
        if(canMove)
        {
            Movement();
            CameraMovement();
        }

        bulletSpawn = GameObject.Find("BulletSpawnR").transform;

        Death();

        if(playerHealth > playerMaxHealth) 
        {
            playerHealth = playerMaxHealth;
        }
    }

    public void Movement()
    {
        if (!isJumping)
        {
            currentVerticalVelocity += Physics.gravity.y * Time.deltaTime;

            if (characterController.isGrounded && currentVerticalVelocity < 0)
            {
                currentVerticalVelocity = Physics.gravity.y * Time.deltaTime;
            }
        }
        else
        {
            jumpTimer += Time.deltaTime;

            if (jumpTimer >= jumpMaxTime)
            {
                isJumping = false;
            }
        }

        Vector3 currentVelocity = new Vector3(currentHorizontalVelocity.x, currentVerticalVelocity, currentHorizontalVelocity.y);

        Vector3 horizontalDirection = Vector3.Scale(currentVelocity, new Vector3(1, 0, 1));
        if (horizontalDirection.magnitude > 0.0001)
        {
            Quaternion newDirection = Quaternion.LookRotation(horizontalDirection.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * moveAcceleration);
        }

        characterController.Move(currentVelocity * Time.deltaTime);
    }

    public void CameraMovement()
    {
        Vector3 cameraSpaceMovement = new Vector3(moveInput.x, 0, moveInput.y);
        cameraSpaceMovement = playerCamera.transform.TransformDirection(cameraSpaceMovement);

        Vector2 cameraHorizontalMovement = new Vector2(cameraSpaceMovement.x, cameraSpaceMovement.z);

        currentHorizontalVelocity = Vector2.Lerp(currentHorizontalVelocity, cameraHorizontalMovement * maxSpeed, Time.deltaTime * moveAcceleration);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); 
    }

    public void OnJump(InputValue value) 
    {
        jumpInputPressed = value.Get<float>() > 0f;
        if(jumpInputPressed) 
        {
            if(characterController.isGrounded) 
            {
                isJumping = true;

                jumpTimer = 0;

                currentVerticalVelocity = jumpSpeed;
            }
        }
        else
        {
            if(isJumping) 
            {
                isJumping = false;
            }
        }
    }

    public void OnAttack(InputValue value)
    {
        if (canMove)
        {
            animateArm.armMove(true);
        }
    }

    public void ThrowBall()
    {
        GameObject bulletCopy = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        bulletCopy.GetComponent<Bullets>().Shoot();
    }

    public void Death()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Project 2");
        }
        else if(playerHealth <= playerMaxHealth / 5) 
        {
            lowHealthAnimator.SetBool("LowHealth", true);
        }
        else
        {
            lowHealthAnimator.SetBool("LowHealth", false);
        }
    }

    public void IsHit(float damage)
    {
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
        healthBar.FadeIn();
    }

    public void UpgradeSpeed(float upgrade)
    {
        maxSpeed += upgrade;
        moveAcceleration += upgrade;
    }

    public void UpgradeJump(float upgrade)
    {
        jumpSpeed += upgrade;
        jumpMaxTime += upgrade;
    }

    public void UpgradeHealth(int upgrade)
    {
        playerHealth += upgrade;
        playerMaxHealth += upgrade;
    }

    public void Heal(int upgrade)
    {
        playerHealth += upgrade;
    }

    public void willItMove(bool willMove)
    {
        canMove = willMove;
    }
}
