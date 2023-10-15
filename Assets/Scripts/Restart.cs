using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            SceneManager.LoadScene("Project 2");
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().HitGround();
        }
    }
}
