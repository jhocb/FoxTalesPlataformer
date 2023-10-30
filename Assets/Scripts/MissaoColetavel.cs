using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoColetavel : MonoBehaviour
{

    public int contagemObjetos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contagemObjetos == 6)
        {
            Debug.Log("Missao coletavel completa");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Coletavel") && Input.GetKey(KeyCode.E))
        {
            ContaObjetos();
            other.gameObject.SetActive(false);
        }
    }
    void ContaObjetos()
    {
        contagemObjetos++;
    }
}
