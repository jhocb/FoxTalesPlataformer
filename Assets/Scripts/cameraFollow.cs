using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject Focus;
    public GameObject Player;
    public float followSpeed = 5.0f; // Adjust this to control the follow speed
    public float distanceX;
    public float distanceY;
    public float distanceZ;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = Focus.transform.position; // Initialize the target position
    }

    private void LateUpdate()
    {
        // Calculate the desired target position
        targetPosition = new Vector3(Player.transform.position.x + distanceX, Player.transform.position.y + distanceY, Player.transform.position.z + distanceZ);

        // Smoothly interpolate the focus position towards the target position
        Focus.transform.position = Vector3.Lerp(Focus.transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
