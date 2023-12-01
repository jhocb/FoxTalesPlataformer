using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreiaReset : MonoBehaviour
{
    public Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("CUBO"))
        {
            gameObject.transform.position = originalPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CUBO"))
        {
            gameObject.transform.position = originalPos;
        }
    }
}
