using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TochaRange : MonoBehaviour
{
    bool playerInRange;
    public Light pointLight;
    public int startingRange;
    public float valueDecrease;
    public GameObject lightPlayer;
    public CheckPoint checkPoint;

    private void Start()
    {
        pointLight.range = startingRange;
        lightPlayer.SetActive(false);
        checkPoint = gameObject.GetComponent<CheckPoint>();
        
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

        if(pointLight.range == 0)
        {
            //checkPoint.VoltouCheckpoint();
            pointLight.range = startingRange;
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

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "InicioTocha")
        {
            lightPlayer.SetActive(true);
        }
        if (other.name == "FinalTocha")
        {
            lightPlayer.SetActive(false);
            valueDecrease = 0;
        }
    }

}
