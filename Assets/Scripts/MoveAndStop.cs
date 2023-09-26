using UnityEngine;

public class MoveAndStop : MonoBehaviour
{
    public float moveSpeed = 2.0f;    // Speed at which the object moves
    public float stopYPosition = 38.0f; // Y position where the object should stop

    private Rigidbody rb;
    private bool isMoving = false;

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

    public void PleaseMove()
    {
        isMoving = true;
    }
}
