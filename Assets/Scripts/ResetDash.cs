using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDash : MonoBehaviour
{
    public Movimento3DAtualizado pM;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerCubo = GameObject.FindGameObjectWithTag("CUBO");
        pM = playerCubo.GetComponent<Movimento3DAtualizado>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CUBO"))
        {
            pM.hasUsedUpwardDash = false;
            //pM.hasUsedSideDash = false;//

            // Desativa o objeto temporariamente
            gameObject.SetActive(false);

            // Invoca o método ReactivateObject() após 3 segundos
            Invoke("ReactivateObject", 3f);
        }
    }

    // Método para reativar o objeto
    void ReactivateObject()
    {
        // Reativa o objeto
        gameObject.SetActive(true);
    }
}