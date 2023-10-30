using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] GameObject player;

    [SerializeField] List<GameObject> checkPoints;

    [SerializeField] Vector3 vectorPoint;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            player.transform.position = vectorPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        vectorPoint = player.transform.position;
    }


}
