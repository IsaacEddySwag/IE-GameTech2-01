using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float launch;

    [SerializeField] private ThirdPersonCharacterController playerController;
    private Rigidbody rb;
    [SerializeField] private GameObject AIMover;

    // Start is called before the first frame update
    void Awake()
    {
        damage = 1;
        launch = 10f;
        playerController = GameObject.Find("3rd Person Player").GetComponent<ThirdPersonCharacterController>();
        rb = GetComponent<Rigidbody>();

        if(rb.velocity == new Vector3(0, 0, 0))
        {
            rb.isKinematic = true;
            //gameObject.transform.rotation = Quaternion.identity;
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerController.IsHit(damage);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            rb.AddExplosionForce(launch, collision.GetContact(0).point, 0.1f, 1, ForceMode.Impulse);
            //rb.useGravity = false;
            //rb.constraints = RigidbodyConstraints.None;
        }
    }
}
