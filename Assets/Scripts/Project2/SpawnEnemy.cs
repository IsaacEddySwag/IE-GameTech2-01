using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float delayTime = 0f;
    public float delayRemove = 10f;
    private float pointCount = 0f;
    public GameObject enemy;
    private ScoreUpdate pointer;

    void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("PointAdder").GetComponent<ScoreUpdate>();
        delayTime = Random.Range(100f, 300f);
        Invoke("Spawning", delayTime - delayRemove);
    }

    private void Update()
    {
        CheckPoints();

    }

    public void Spawning()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        Invoke("Spawning", delayTime - delayRemove);
    }

    public void CheckPoints()
    {
        if (pointer.totalScore >= pointCount + 200)
        {
            delayTime -= delayRemove;
            pointCount = pointer.totalScore;
        }
    }
}
