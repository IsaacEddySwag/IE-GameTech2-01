using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if(Input.GetKeyDown(KeyCode.Escape)) {
            rb.AddForce(gameObject.transform.up * launch);
            rb.AddForce(gameObject.transform.forward * launch);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerController.isHit(damage);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            rb.AddExplosionForce(10, collision.GetContact(0).point, 0.1f, 1, ForceMode.Impulse);

            //collision.GetContact(0).point spawn particle effects

            //rb.AddForce(gameObject.transform.up * launch * Time.deltaTime);
            //rb.AddForce(gameObject.transform.forward * launch * Time.deltaTime);
        }
    }
}
