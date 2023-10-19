using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    Vector3 newPosition;
    public float upAmount = 0.01f;

    private void Start()
    {
        newPosition = transform.position;
    }
    void FixedUpdate()
    {
        newPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + upAmount, gameObject.transform.position.z);

        gameObject.transform.position = newPosition;
    }
}
