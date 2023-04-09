using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideHitDetection : MonoBehaviour
{
    public float damage = 100f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth eHealth = other.gameObject.GetComponent<EnemyHealth>();
            eHealth.curHealth -= damage;
        }
    }
}