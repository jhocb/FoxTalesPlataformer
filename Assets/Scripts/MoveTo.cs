using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform player; // Player object
    public Transform goal; // Goal object
    public Transform goal2; // Goal object
    private float time; // Time variable
    private NavMeshAgent agent; // NavMeshAgent component
    public float distance = 100f; // Distance variable
    Animator animator; // this is the animator component of the enemy 

    // Start is called before the first frame update
    void Start()
    {
        time = 0; // Initialize time to 0
        agent = GetComponent<NavMeshAgent>(); // Get NavMeshAgent component
        animator = GetComponent<Animator>(); // get the Animator component of the enemy 
    }

    void FixedUpdate()
    {

        time += Time.deltaTime; // Increment time by the time between frames

        distance = Vector3.Distance(transform.position, player.transform.position); // Calculate distance between player and goal

        if (time >= 0.5f && (distance <=7f || distance >= 0.7f)) // If time is greater than 0.5 seconds and the distance is less than 10 and greater than 0.5
        {
            goal.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z); // Set goal position to player position
            agent.destination = goal.position; // Set the destination to the goal position
            time = 0f; // Reset time
            animator.SetBool("running", true); // Set running to true
        }

        if(distance >7 || distance < 0.7f){ // if the distance is greater than 7 and less than 0.7
        
            agent.destination = transform.position; // Set the destination to the goal position
            animator.SetBool("running", false); // Set running to false
            
        }
    }
}