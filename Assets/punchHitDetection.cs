using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchHitDetection : MonoBehaviour
{
    public float damage = 40f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.curHealth -= damage;
        }
    }
}