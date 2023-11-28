using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneCall : MonoBehaviour
{
    public int dashCount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "TriggerDash")
        {
            dashCount++;
        }
    }


    private void Update()
    {
        if(dashCount == 3)
        {
            SceneManager.LoadScene("Cutscene");
        }
    }

}
