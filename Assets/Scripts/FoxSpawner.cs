using System.Collections;
using UnityEngine;


public class FoxSpawner : MonoBehaviour
{
    public GameObject objetoPrefab;
    public Vector3 tamanhoDaZona;
    public float tempoEntreSpawns = 3.0f;
    public float velocidadeMovimento = 5.0f; // Velocidade de movimento


    private void Start()
    {
        StartCoroutine(SpawnLoop());
        //anim = GameObject.Find("RaposaAnimadaV2 Variant").GetComponent<Animator>();
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            // Instanciar objeto aleatoriamente dentro da área especificada
            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-tamanhoDaZona.x / 2, tamanhoDaZona.x / 2),
                0,
                Random.Range(-tamanhoDaZona.z / 2, tamanhoDaZona.z / 2)
            );
            GameObject novoObjeto = Instantiate(objetoPrefab, spawnPosition, Quaternion.identity);
            MoveObjectForward(novoObjeto);
            //MoveObjectForward(novoObjeto.transform);
            /*GameObject novoObjeto = Instantiate(objetoPrefab, spawnPosition, Quaternion.identity);*/
            
            yield return new WaitForSeconds(tempoEntreSpawns);
        }
    }
    /*void MoveObjectForward(Transform objTransform)
    {
        // Mover o objeto para frente automaticamente
        objTransform.Translate(Vector3.forward * velocidadeMovimento * Time.deltaTime);
    }*/
    void MoveObjectForward(GameObject novoObjeto)
    {
        Rigidbody rb = novoObjeto.GetComponent<Rigidbody>();

        // Mover o objeto para frente automaticamente
        if (rb != null)
        {
            Debug.Log("Peguei o RB");
            rb.velocity = novoObjeto.transform.forward * 5.0f; // Ajuste a velocidade conforme necessário
        }
        else
            Debug.Log("no rb");
    }
}
