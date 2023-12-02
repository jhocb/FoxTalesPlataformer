using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreiaReset : MonoBehaviour
{
    public GameObject areia;

    public Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = areia.transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("CUBO"))
        {
            areia.transform.position = originalPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CUBO"))
        {
            areia.transform.position = originalPos;
        }
    }
}
