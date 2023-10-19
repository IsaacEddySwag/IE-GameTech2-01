using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    Vector3 newPosition;
    public float upAmount = 0.01f;

    //On load sets the vector 3 new position to be the current location of the water
    private void Start()
    {
        newPosition = transform.position;
    }
    void FixedUpdate()
    {
        //Sets new position tp be equal to its same x and z positions but the y position is set equal to its y position plus the up amount
        newPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + upAmount, gameObject.transform.position.z);
        //The position of the game object is set equal to the new position
        gameObject.transform.position = newPosition;
    }
}
