using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private ThirdPersonCharacterController playerController;
    [SerializeField] private ScoreUpdate scoreUpdater;
    public Rigidbody rb;
    [SerializeField] private GameObject AIMover;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        damage = 1;
        playerController = GameObject.Find("3rd Person Player").GetComponent<ThirdPersonCharacterController>();
        scoreUpdater = GameObject.Find("PointAdder").GetComponent<ScoreUpdate>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerController.IsHit(damage);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            scoreUpdater.AddScore();
            Debug.Log("Hit");
            Death();
            //Instantiate(bloodEffect, collision.GetContact(0).point, Quaternion.identity);
        }

    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
