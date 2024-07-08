using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    public Transform[] wayPoints;

    private int currentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.SetDestination(wayPoints[currentWaypointIndex].position);

    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % wayPoints.Length;
            navMeshAgent.SetDestination(wayPoints[currentWaypointIndex].position);

        }
        
    }
}
