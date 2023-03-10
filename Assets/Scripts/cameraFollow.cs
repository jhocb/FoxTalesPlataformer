using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraFollow : MonoBehaviour
{

    public GameObject Focus;
    public GameObject Player;

    // Update is called once per frame
    void FixedUpdate()
    {
        Focus.transform.position = Player.transform.position;
    }
}
