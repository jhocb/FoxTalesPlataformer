using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcBehaviour : MonoBehaviour
{
    
    public Transform target; // Target to follow
    private float distance; // Distance variable
    Animator animator; // this is the animator component of the enemy 

    void Start()
    {
        animator = GetComponent<Animator>(); // get the Animator component of the enemy
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, target.transform.position); // Calculate distance between player and goal

        transform.LookAt(target); // Look at target

        animator.SetFloat("distance", distance); // Set distance to animator
    }
}
