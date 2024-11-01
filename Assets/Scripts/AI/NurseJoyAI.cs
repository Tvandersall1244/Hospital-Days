using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]


public class NewBehaviourScript : MonoBehaviour
{

    public Animator anim;
    private NavMeshAgent agent;
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    public bool notWaiting = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentWaypoint = 0;
        //set the first waypoint as the destination
        setNextWaypoint();
        Debug.Log("going to first waypoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.05f && currentWaypoint < waypoints.Length && agent.pathPending == false && notWaiting)
        {
            setNextWaypoint();
            Debug.Log("going to next waypoint");
        }

        //if player presses e, notwaiting set to true
        //TODO: NEEDS TO MOVED AND HANDLED IN A CONVERSATION SYSTEM (notwaiting WILL BE SET TO TRUE THERE)
        if (Input.GetKeyDown(KeyCode.E) && notWaiting == false)
        {
            notWaiting = true;
            Debug.Log("waiting");
        }

        
    }

    private void setNextWaypoint()
    {
        //set the destination of the agent to the current waypoint
        agent.SetDestination(waypoints[currentWaypoint].transform.position);
        //increment the current waypoint
        

        if (waypoints[currentWaypoint].name == "Gashapon") {
            notWaiting = false;
        }
        currentWaypoint++;
    }
}
