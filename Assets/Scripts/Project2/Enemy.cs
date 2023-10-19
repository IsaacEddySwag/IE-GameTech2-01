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
    [SerializeField] ParticleSystem bloodEffect;

    // Start is called before the first frame update
    void Awake()
    {
        //Gets the scripts ThirdPersonCharacterController and ScoreUpdate from objects in scene and sets them to variables
        playerController = GameObject.Find("3rd Person Player").GetComponent<ThirdPersonCharacterController>();
        scoreUpdater = GameObject.Find("PointAdder").GetComponent<ScoreUpdate>();
        //Gets the rigidbody from the game object and sets it to a variable
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the object collides with another with the tag player call the damage function on the player script
        if (collision.gameObject.tag == "Player") 
        {
            playerController.IsHit(damage);
        }

        //If object is hit by object with the tag bullet
        if(collision.gameObject.tag == "Bullet")
        {
            //Add 20 score to the score variable
            scoreUpdater.AddScore();
            //Instantiate a blood particle effect
            Instantiate(bloodEffect, collision.GetContact(0).point, Quaternion.identity);
            //Activate the death function, which destroys the game object
            Death();
        }

    }

    //Once called destrot this game object
    public void Death()
    {
        Destroy(this.gameObject);
    }
}
