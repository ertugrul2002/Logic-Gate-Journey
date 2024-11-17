using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private NavMeshAgent  navAgent;

    private void Start()
    {
        navAgent =GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Creat a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //check if the ray hits the ground (Navmesh)
            if(Physics.Raycast(ray,out hit,Mathf.Infinity,NavMesh.AllAreas))
            {
                //Move the agent to the clicked position
                navAgent.SetDestination(hit.point);
            }
        }
    }
}
