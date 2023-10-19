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
        //Gets the score update script from an object in scene and sets it to a variable
        pointer = GameObject.FindGameObjectWithTag("PointAdder").GetComponent<ScoreUpdate>();
        //Sets the delay time to be a random amount of time between 100 and 300 seconds
        delayTime = Random.Range(100f, 300f);
        //Invokes the spawning function which spawns enemies on delay by the delay time
        Invoke("Spawning", delayTime);
    }

    private void Update()
    {
        //Invokes the check points function every frame
        CheckPoints();
    }

    public void Spawning()
    {
        //Instaniates an enemy at the transform of the object
        Instantiate(enemy, transform.position, Quaternion.identity);
        //Invokes spawning again by delay time, create an endless loop of spawning
        Invoke("Spawning", delayTime);
    }

    public void CheckPoints()
    {
        //Checks if the points player exceeds 200 points over their current amount
        if (pointer.totalScore >= pointCount + 200)
        {
            //Removes 10 from the delay time
            delayTime -= delayRemove;
            //Updates the point count to be accurately checked again next frame
            pointCount = pointer.totalScore;
        }
    }
}
