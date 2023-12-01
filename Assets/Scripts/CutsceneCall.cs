using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneCall : MonoBehaviour
{
    public int dashCount;
    public List<GameObject> fogosAlcapao;
    public int indiceAtivo = 0;
    private void Start()
    {
        foreach (GameObject objeto in fogosAlcapao)
        {
            objeto.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "TriggerDash")
        {
            dashCount++;
            fogosAlcapao[indiceAtivo].SetActive(true);
            indiceAtivo++;
        }
    }


    private void Update()
    {
        if(dashCount == 3)
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
