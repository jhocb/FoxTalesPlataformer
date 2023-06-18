using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{
    public float damage = 40f; // damage dealt to enemy

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // if the object that enters the trigger is tagged as an enemy
        {
            playerHealth playerHealth = other.gameObject.GetComponent<playerHealth>(); // get enemy health script
            playerHealth.curHealth -= damage; // subtract damage from enemy health
        }
    }
}
