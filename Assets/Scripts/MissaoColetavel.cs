using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoColetavel : MonoBehaviour
{
    [SerializeField]
    public static int contagemObjetos;
    public List<GameObject> fogosTotens;
    public GameObject barreiraPuzzle;
    // Start is called before the first frame update
    void Start()
    {
        barreiraPuzzle = GameObject.Find("PuzzleColetaveisBarreira");
        //fogosTotens = new List<GameObject>();
        fogosTotens.AddRange(GameObject.FindGameObjectsWithTag("Fogos"));
        foreach (var objeto in fogosTotens)
        {
            objeto.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (contagemObjetos >= 6)
        {
            Debug.Log("Missao coletavel completa");
            barreiraPuzzle.SetActive(false);
        }

        /*if (contagemObjetos < 6)
        {
            foreach (var objeto in fogosTotens)
            {
                objeto.SetActive(false);
            }
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Coletavel"))
        {
            ContaObjetos();
            other.gameObject.SetActive(false);
        }
    }
    void ContaObjetos()
    {
        contagemObjetos++;

        if (contagemObjetos <= fogosTotens.Count)
        {
            // Ativa o objeto correspondente na lista
            fogosTotens[contagemObjetos - 1].SetActive(true);
        }
    }


}
