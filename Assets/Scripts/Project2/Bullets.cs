using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Rigidbody rb;
    private Raycast raycast;

    public float shotSpeed = 5f;
    public bool isShooting = false;

    private Vector3 hitLocation;

    public ParticleSystem puff;
    

    private void Awake()
    {
        //Gets the rigidbody component of the object and the raycast on the main camera and sets them to variables
        rb = GetComponent<Rigidbody>();
        raycast = GameObject.Find("Main Camera").GetComponent<Raycast>();
    }

    private void Update()
    {
        //Checks if the bool isShooting is true
        if (isShooting)
        {
            //A variable is created and is assigned shotSpeed times delta time
            var step = shotSpeed * Time.deltaTime;
            //The objects transform is set to move towards the hit location of the raycast by the speed set in step
            transform.position = Vector3.MoveTowards(transform.position, hitLocation, step);
        }
        if(transform.position ==  hitLocation)
        {
            //Once the objects transform is equal to the hit location of the ray cast isShooting is set to false
            isShooting = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //When the object hits something a particle effect is instantiated and the object is destroyed.
        Instantiate(puff, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        Destroy(this.gameObject);
    }

    //Sets hit location to be the point where the raycast hits and sets isShooting to true letting the object move in update
    public void Shoot()
    {
        hitLocation = raycast.hit;
        isShooting = true;
    }
}
