using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class MoveToDestination : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    //On Awake sets the target destination to the game object Destination points transform
    private void Awake()
    {
        target = GameObject.Find("DestinationPoint").transform;
    }

    //Gets the navmesh agent componnent from the object then sets the destination of that object to be the position of destination point
    private void Update()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = target.position;
    }
}
