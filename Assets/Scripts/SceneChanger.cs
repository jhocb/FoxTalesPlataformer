using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    //public GameObject spawnPoint;
    public Vector3 spawnPosition;
    public GameObject playerChar;
    // Start is called before the first frame update
    void Start()
    {
        //spawnPosition = spawnPoint.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CUBO"))
        {
            SceneManager.LoadScene("Tower");

            SceneManager.LoadScene("Standard", LoadSceneMode.Additive);

            playerChar.transform.position = spawnPosition;

            this.gameObject.SetActive(false);
        }
    }
}
