using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float delayTime = 0f;
    public float delayRemove = 10f;
    public GameObject enemy;
    private ScoreUpdate pointer;

    void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("PointAdder").GetComponent<ScoreUpdate>();
        CheckPoints();
        delayTime = Random.Range(30, 400);
        Invoke("Spawning", delayTime - delayRemove);
    }

    public void Spawning()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        Invoke("Spawning", delayTime - delayRemove);
    }

    public void CheckPoints()
    {
        delayRemove += pointer.totalScore / 10;
    }
}
