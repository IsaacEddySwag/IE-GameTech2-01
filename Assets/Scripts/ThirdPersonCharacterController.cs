using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;

[RequireComponent(typeof(CharacterController))]

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float maxSpeed = 3f;
    public float moveAcceleration = 6f;

    public float jumpSpeed = 5f;
    public float jumpMaxTime = 0.5f;
    public float jumpTimer = 0f;

    public float playerHealth = 5f;

    private CharacterController characterController;

    public GameObject bullet;

    private Vector2 moveInput = Vector2.zero;
    private Vector2 currentHorizontalVelocity = Vector2.zero;
    private float currentVerticalVelocity;

    private bool jumpInputPressed;
    private bool isJumping;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        currentHorizontalVelocity = Vector2.Lerp(currentHorizontalVelocity, moveInput * maxSpeed, Time.deltaTime * moveAcceleration);

        if(!isJumping)
        {
            currentVerticalVelocity += Physics.gravity.y * Time.deltaTime;
            
            if(characterController.isGrounded && currentVerticalVelocity < 0)
            {
                currentVerticalVelocity = Physics.gravity.y * Time.deltaTime;
            }
        }
        else
        {
            jumpTimer += Time.deltaTime;

            if(jumpTimer >= jumpMaxTime)
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

        death();

        if(Input.GetKeyDown("f"))
        {
            tempHit();
        }
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
        Collider[] overlapItems = Physics.OverlapBox(transform.position, Vector3.one);

        if(overlapItems.Length > 0) 
        {
            foreach(Collider item in overlapItems) 
            {
                Vector3 direction = item.transform.position - transform.position;
                item.SendMessage("OnPlayerAttack", direction, SendMessageOptions.DontRequireReceiver);
            }
        }

        GameObject bulletCopy = Instantiate(bullet);
        bulletCopy.transform.position = transform.forward;
        bulletCopy.GetComponent<Bullets>().Shoot(new Vector3(currentHorizontalVelocity.x, 0, currentHorizontalVelocity.y));

    }

    public void tempHit()
    {
        playerHealth -= 1;
    }

    public void death()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }
    }

    public void isHit(float damage)
    {
        playerHealth -= damage;
    }
}
