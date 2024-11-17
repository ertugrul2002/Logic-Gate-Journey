using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombiePtrolingState : StateMachineBehaviour
{
    float timer;
    public float patrolingTime = 10f;
    Transform player;
    NavMeshAgent agent;

    public float detectionArea = 18f ;
    public float patrolSpeed =2f;
    List<Transform> waypointsList = new List<Transform>();
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Initialization
       player = GameObject.FindGameObjectWithTag("Player").transform;
       agent = animator.GetComponent<NavMeshAgent>();
       agent.speed = patrolSpeed;
       timer =0;
        // get all waypoint and move to First WayPoint
        GameObject waypointCluster =GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform t in waypointCluster.transform)
        {
            waypointsList.Add(t);
        }
        Vector3 nextPotion = waypointsList[Random.Range(0,waypointsList.Count)].position;
        agent.SetDestination(nextPotion);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(SoundManager.Instace.zombieChannel1.isPlaying == false)
        {
            SoundManager.Instace.zombieChannel1.clip = SoundManager.Instace.zombieWalking;
            SoundManager.Instace.zombieChannel1.PlayDelayed(1f);
        }

        // if agent arrived at waypoint, move to next waypoint 
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypointsList[Random.Range(0,waypointsList.Count)].position);   
        }
        // --- Transition to Patrol State --- //
        timer+= Time.deltaTime;
        if( timer > patrolingTime)
        {
            animator.SetBool("isPatroling",false);
        }
        // --- Transition to chase State --- //
        float distanceFromPlayer = Vector3.Distance(player.position,animator.transform.position);
        if(distanceFromPlayer < detectionArea)
        {
            animator.SetBool("isChassing",true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Stop the agent
       agent.SetDestination(agent.transform.position);
       SoundManager.Instace.zombieChannel1.Stop();
    }
}
