using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private List<Health> _objectsWithHealth = new();

    [SerializeField]
    private Animator _animator;

    private void OnFire()
    {
        _animator.SetTrigger("Attack");
        for (var i = _objectsWithHealth.Count - 1; i >= 0; i--)
        {
            _objectsWithHealth[i].Damage(3);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        var health = col.GetComponent<Health>();
        if (health != null )
        {
            _objectsWithHealth.Add(health);
        }
    }
    
    private void OnTriggerExit(Collider col)
    {
        if (col.TryGetComponent<Health>(out var health) && _objectsWithHealth.Contains(health))
        {
            _objectsWithHealth.Remove(health);
        }
    }

}
