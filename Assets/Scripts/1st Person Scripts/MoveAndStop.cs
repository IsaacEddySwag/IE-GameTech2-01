using Unity.VisualScripting;
using UnityEngine;

public class MoveAndStop : MonoBehaviour
{
    public float moveSpeed = 2.0f;    // Speed at which the object moves
    public float stopYPosition = 38.0f; // Y position where the object should stop

    private Rigidbody rb;
    private bool isMoving = false;

    //Gets the rigidbody of the script and sets the stop position to be 38f over the current position
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stopYPosition = transform.position.y + stopYPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the object upwards
            rb.velocity = new Vector3(0, moveSpeed, 0);

            // Check if the object has reached the desired Y position
            if (transform.position.y >= stopYPosition)
            {
                // Stop the object
                isMoving = false;
                rb.velocity = Vector3.zero;
            }
        }
    }

    //Sets isMoving to true when called to activate the movement of the object
    public void PleaseMove()
    {
        isMoving = true;
    }
}
