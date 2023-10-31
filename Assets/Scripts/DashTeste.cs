using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTEste : MonoBehaviour
{
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    private bool isDashing = false;
    private Vector3 dashDirection;
    private float dashTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true;
            dashDirection = transform.forward;  // Por exemplo, você pode fazer o dash para frente.
            dashTime = Time.time + dashDuration;
        }
        if (isDashing && Time.time < dashTime)
        {
          //  characterController.Move(dashDirection * dashSpeed * Time.deltaTime);
        }
        else
        {
            isDashing = false;
        }

    }
}
