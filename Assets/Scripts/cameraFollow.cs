using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraFollow : MonoBehaviour
{

    public GameObject Focus;
    public GameObject Player;
    public float distanceX;
    public float distanceY;
    public float distanceZ;
    // Update is called once per frame
    void FixedUpdate()
    {
        //Focus.transform.position.x = Player.transform.position.x;
        Focus.transform.position = new Vector3(Player.transform.position.x + distanceX, Player.transform.position.y + distanceY, Player.transform.position.z + distanceZ);
    }
}
