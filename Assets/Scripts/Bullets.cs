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
        rb = GetComponent<Rigidbody>();
        raycast = GameObject.Find("Main Camera").GetComponent<Raycast>();
    }

    private void Update()
    {
        if (isShooting)
        {
            var step = shotSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, hitLocation, step);
        }
        if(transform.position ==  hitLocation) w
        {
            isShooting = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(puff, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void Shoot()
    {
        hitLocation = raycast.hit;
        isShooting = true;
    }
}
