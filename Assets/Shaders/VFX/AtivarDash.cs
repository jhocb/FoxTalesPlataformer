using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarDash : MonoBehaviour
{

    public GameObject VFXDash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("CUBO") && Input.GetKeyDown(KeyCode.L) || other.CompareTag("CUBO") && Input.GetKeyDown(KeyCode.J))
        {
            VFXDash.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CUBO"))
            VFXDash.SetActive(false);
    }

}
