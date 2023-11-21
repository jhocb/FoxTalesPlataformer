using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDialogo : MonoBehaviour
{
    public GameObject dialogo;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("CUBO"))
        dialogo.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("CUBO"))
        dialogo.SetActive(false);
    }

}
