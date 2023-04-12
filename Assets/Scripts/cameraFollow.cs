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
        //Focus.transform.position.x = Player.transform.position.x;
        Focus.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.5f, 0f);
    }
}
