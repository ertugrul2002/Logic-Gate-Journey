using UnityEngine;

public class ZombieIdleState : StateMachineBehaviour
{
    float timer;
    public float idleTime =0f;
    Transform player;
    public float detectionAreaRadius = 18f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timer =0;
       player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // --- Transition to Patrol State --- //
        timer +=Time.deltaTime;
        if(timer > idleTime)
        {
            animator.SetBool("isPatroling",true);
        }
        // --- Transition to chase State --- //
        float distanceFromPlayer = Vector3.Distance(player.position,animator.transform.position);
        if(distanceFromPlayer < detectionAreaRadius)
        {
            animator.SetBool("isChassing",true);
        }
    }

   

   
}
