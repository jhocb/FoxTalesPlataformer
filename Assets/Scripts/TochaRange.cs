using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TochaRange : MonoBehaviour
{
    bool playerInRange;
    public Light pointLight;
    public int startingRange;
    public float valueDecrease;

    private void Start()
    {
        pointLight = gameObject.GetComponent<Light>();
        pointLight.range = startingRange;
    }

    private void Update()
    {
        if (playerInRange == false)
        {
            pointLight.range -= valueDecrease * Time.deltaTime;
            print("nao esta no range");
        }
        else
        {
            print("esta no range");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TochaGrande"))
        {
            playerInRange = true;
            pointLight.range = startingRange;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TochaGrande"))
        {
            playerInRange = false;
        }
    }
}
