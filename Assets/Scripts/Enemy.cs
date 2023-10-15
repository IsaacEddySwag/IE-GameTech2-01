using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float launch;

    [SerializeField] private ThirdPersonCharacterController playerController;
    [SerializeField] private ScoreUpdate scoreUpdater;
    public Rigidbody rb;
    [SerializeField] private GameObject AIMover;
    [SerializeField] private bool hitGroundAfter = false;

    // Start is called before the first frame update
    void Awake()
    {
        damage = 1;
        launch = 10f;
        playerController = GameObject.Find("3rd Person Player").GetComponent<ThirdPersonCharacterController>();
        scoreUpdater = GameObject.Find("PointAdder").GetComponent<ScoreUpdate>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (hitGroundAfter)
        {
            HitGround();
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
            Invoke("DestroyAfterHit", 1f);
        }

    }

    private void DestroyAfterHit()
    {
        hitGroundAfter = true;
    }

    public void HitGround()
    {
        scoreUpdater.AddScore();
        Destroy(this.gameObject);
    }
}
