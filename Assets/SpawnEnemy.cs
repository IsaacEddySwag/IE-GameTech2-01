using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float delayTime = 0f;
    public GameObject enemy;
    void Start()
    {
        delayTime = Random.Range(5, 41);
        Invoke("Spawning", delayTime);
    }

    public void Spawning()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
