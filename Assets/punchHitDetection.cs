using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchHitDetection : MonoBehaviour
{
    public float damage = 40f; // damage dealt to enemy

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) // if the object that enters the trigger is tagged as an enemy
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>(); // get enemy health script
            enemyHealth.curHealth -= damage; // subtract damage from enemy health
        }
    }
}