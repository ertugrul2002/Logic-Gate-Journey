using UnityEngine;
using UnityEngine.AI;

public class ZombieChassState : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent agent;
    public float chaseSpeed = 6f;
    public float stopChasingDistance =21;
    public float attackingDistance= 2.5f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Initialization
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed= chaseSpeed;

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(SoundManager.Instace.zombieChannel1.isPlaying == false)
        {
            SoundManager.Instace.zombieChannel1.PlayOneShot(SoundManager.Instace.zombieChase);
        }
        agent.SetDestination(player.position);
        animator.transform.LookAt(player);

        float distaceFromPlayer =Vector3.Distance(player.position,animator.transform.position);
        // cheacking if the agent should stop Chasing
        if(distaceFromPlayer > stopChasingDistance)
        {
            animator.SetBool("isChassing",false);
        }
        // cheacking if the agent should Attack
        if(distaceFromPlayer < attackingDistance)
        {
            animator.SetBool("isAttacking",true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        SoundManager.Instace.zombieChannel1.Stop();
    }
}
