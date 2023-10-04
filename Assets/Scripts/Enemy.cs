using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float launch;

    [SerializeField] private ThirdPersonCharacterController playerController;
    private Rigidbody rb;

    [SerializeField] private ParticleSystem puff;

    // Start is called before the first frame update
    void Awake()
    {
        damage = 1f;
        launch = 10f;
        playerController = GameObject.Find("3rd Person Player").GetComponent<ThirdPersonCharacterController>();
        rb = GetComponent<Rigidbody>();
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
        }
    }
}
