using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] GameObject player;

    [SerializeField] List<GameObject> checkPoints;

    [SerializeField] Vector3 vectorPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("CUBO");
        checkPoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
    }

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


        if (other.CompareTag("Perigo"))
        {
            player.transform.position = vectorPoint;
        }
    }


}
