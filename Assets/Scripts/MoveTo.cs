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
    private float punchTime; // Time variable

    private NavMeshAgent agent; // NavMeshAgent component
    Animator animator; // Animator component of the enemy

    public float distance = 100f; // Distance variable
    public float maxDistance = 4f; // Max distance variable
    public float minDistance = 0.85f; // Min distance variable
    public float refreshRate = 0.5f; // Refresh rate variable
    public float punchDistance = 0.95f; // Punch distance variable
    public float punchCooldown = 1f; // Punch cooldown variable
    public float punchReset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        time = 0; // Initialize time to 0
        punchTime = 0; // Initialize time to 0
        agent = GetComponent<NavMeshAgent>(); // Get NavMeshAgent component
        animator = GetComponent<Animator>(); // Get the Animator component of the enemy
    }

    void Update()
    {
        time += Time.deltaTime; // Increment time by the time between frames
        punchTime += Time.deltaTime; // Increment time by the time between frames

        distance = Vector3.Distance(transform.position, player.transform.position); // Calculate distance between player and goal

        if (time >= refreshRate && (distance <= maxDistance || distance >= minDistance))
        { // If time is greater than 0.5 seconds and the distance is less than 10 and greater than 0.5
            goal.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z); // Set goal position to player position
            agent.destination = goal.position; // Set the destination to the goal position
            time = 0f; // Reset time
            animator.SetBool("running", true); // Set running to true
        }

        if (distance > maxDistance || distance < minDistance)
        { // if the distance is greater than 7 and less than 0.7
            agent.destination = transform.position; // Set the destination to the goal position
            animator.SetBool("running", false); // Set running to false
        }

        if (distance <= punchDistance && punchTime >= punchCooldown)
        { // if the distance is less than 0.7
            animator.SetBool("punching", true); // Set punching to true
            punchTime = 0f; // Reset punch time
            StartCoroutine(ResetPunchingAnimation()); // Start the coroutine to reset the punching animation
        }

        /*if(punchTime<punchCooldown){
            animator.SetBool("punching", false); // Set punching to true

        }*/
        
    }

    IEnumerator ResetPunchingAnimation()
    {
        yield return new WaitForSeconds(punchReset);
        animator.SetBool("punching", false); // Set punching to false
    }
}

