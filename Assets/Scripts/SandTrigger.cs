using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandTrigger : MonoBehaviour
{
    public GameObject sandObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CUBO"))
        {
            sandObject.SetActive(true);
        }
    }
}
