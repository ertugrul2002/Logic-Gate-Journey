using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int HP =100;
    private Animator animator;
    private NavMeshAgent navAgent;
    public bool isDead;
    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }
    public void TakeDamage(int damageAmount)
    {
        HP-= damageAmount;

        if(HP <= 0)
        {
            int raandomValue = Random.Range(0,2); // 0 or 1
            if(raandomValue == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {
                animator.SetTrigger("DIE2");
            }   
            isDead =true;
            //Dead Sound
            SoundManager.Instace.zombieChannel1.PlayOneShot(SoundManager.Instace.zombieDeath);
            Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("DAMAGE");
            // Hurt Sound
            SoundManager.Instace.zombieChannel2.PlayOneShot(SoundManager.Instace.zombieHurt);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color =Color.red;
        Gizmos.DrawWireSphere(transform.position,2.5f); // Stop Attacking

        Gizmos.color =Color.blue;
        Gizmos.DrawWireSphere(transform.position,2.5f); // Detection (start Chasing)

        Gizmos.color =Color.green;
        Gizmos.DrawWireSphere(transform.position,2.5f); // Stop chasing
    }

    
}
