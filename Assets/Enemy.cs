using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage;
    public float launch;

    public ThirdPersonCharacterController playerController;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        damage = 1f;
        launch = 10f;
        playerController = GameObject.Find("3rd Person Player").GetComponent<ThirdPersonCharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerController.isHit(damage);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            rb.AddForce(transform.up * launch);
        }
    }
}
