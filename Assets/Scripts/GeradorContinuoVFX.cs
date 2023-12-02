using System.Collections;
using UnityEngine;


public class GeradorContinuoVFX : MonoBehaviour
{
    public GameObject[] windsVFX;
    public Vector3 tamanhoDaZona;
    public float tempoEntreSpawns = 3.0f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            // Instanciar objeto aleatoriamente dentro da área especificada
            GameObject objetoEscolhido = windsVFX[Random.Range(0, windsVFX.Length)];

            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-tamanhoDaZona.x / 2, tamanhoDaZona.x / 2),
                0,
                Random.Range(-tamanhoDaZona.z / 2, tamanhoDaZona.z / 2)

            );
            GameObject novoObjeto = Instantiate(objetoEscolhido, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(tempoEntreSpawns);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, tamanhoDaZona);
    }
}
