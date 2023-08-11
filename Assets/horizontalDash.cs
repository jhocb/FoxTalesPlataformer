using UnityEngine;
using System.Collections;

public class horizontalDash : MonoBehaviour
{
    public float dashForce = 10f;           // The force applied for the horizontal dash
    public float dashDuration = 0.2f;       // The duration of the dash
    public float slowdownFactor = 0.5f;     // The factor by which velocity is reduced after dashing

    private bool isDashing = false;         // Flag to track if the object is currently dashing
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !isDashing)
        {
            DashHorizontal();
        }
    }

    private void DashHorizontal()
    {
        isDashing = true;

        // Determine the dash direction based on the object's current forward direction
        Vector3 dashDirection = transform.forward;

        // Apply horizontal force to the Rigidbody
        rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);

        // Start a coroutine to end the dash after a certain duration
        StartCoroutine(EndDash());

        Debug.Log("Dashing horizontally");
    }

    private IEnumerator EndDash()
    {
        // Wait for the specified dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reduce the object's velocity to achieve a controlled slowdown
        rb.velocity *= slowdownFactor;

        // Disable the dashing flag to allow another dash
        isDashing = false;
    }
}
