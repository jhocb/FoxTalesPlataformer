using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public int punchDamage = 10;
    public int kickDamage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (gameObject.CompareTag("Punch"))
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(punchDamage);
            }
            else if (gameObject.CompareTag("Kick"))
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(kickDamage);
            }
        }
    }
}