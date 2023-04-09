using UnityEngine;
using System.Collections;
 
public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // this is the max health of the enemy
    public float curHealth; // this is the current health of the enemy

    Animator animator; // this is the animator component of the enemy
 
    void Start() {

        curHealth = maxHealth; // set the current health to the max health
        animator = GetComponent<Animator>(); // get the Animator component of the enemy
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth > maxHealth) // if the current health is greater than the max health
        {
            curHealth = maxHealth; // set the current health to the max health
        }
        if (curHealth <= 0) // if the current health is less than or equal to 0
        {
            //Destroy(gameObject); // destroy the enemy
            animator.SetBool("gotHitted", true);
        }
    }   
}