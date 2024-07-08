using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    public Transform[] wayPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.SetDestination(wayPoints[0].position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
