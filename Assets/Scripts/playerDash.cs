using UnityEngine;
using System.Collections;
using Climbing;


public class playerDash : MonoBehaviour
{
    public float upwardDashForce = 10f;     // The force applied for the upward dash
    public float horizontalDashForce = 10f; // The force applied for the horizontal dash

    public float upwardDashDuration = 0.2f;     // The duration of the upward dash
    public float horizontalDashDuration = 0.2f; // The duration of the horizontal dash

    public float slowdownFactor = 0.5f;     // The factor by which velocity is reduced after dashing

    private bool isDashing = false;         // Flag to track if the object is currently dashing
    private Rigidbody rb;
    private ThirdPersonController controller; // Assuming you have this script

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        if (!isDashing)
        {
            if (Input.GetKeyDown(KeyCode.G) && controller.isGrounded)
            {
                Dash(Vector3.up, upwardDashForce, upwardDashDuration);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                Dash(transform.forward, horizontalDashForce, horizontalDashDuration);
            }
        }
    }

    private void Dash(Vector3 dashDirection, float dashForce, float dashDuration)
    {
        isDashing = true;

        // Apply force to the Rigidbody based on dashDirection
        rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);

        // Start a coroutine to end the dash after a certain duration
        StartCoroutine(EndDash(dashDuration));

        Debug.Log("Dashing");
    }

    private IEnumerator EndDash(float dashDuration)
    {
        // Wait for the specified dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reduce the object's velocity to achieve a controlled slowdown
        rb.velocity *= slowdownFactor;

        // Disable the dashing flag to allow another dash
        isDashing = false;
    }
}
