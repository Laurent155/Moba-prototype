using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log("The ray hit at: " + hit.point);
            
                agent.SetDestination(hit.point);
            }
        }

        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Speed", speed, 0.1f, Time.deltaTime);

    }

}
