using UnityEngine;
using System.Collections;
using Climbing;

public class playerDash : MonoBehaviour
{
    public bool dashingUp = false; // Boolean to track if the player is dashing upwards
    public bool dashingForward = false; // Boolean to track if the player is dashing forward

    public float upwardDashForce = 10f;     // The force applied for the upward dash
    public float horizontalDashForce = 10f; // The force applied for the horizontal dash

    public float upwardDashDuration = 0.2f;     // The duration of the upward dash
    public float horizontalDashDuration = 0.2f; // The duration of the horizontal dash

    public float slowdownFactor = 0.5f;     // The factor by which velocity is reduced after dashing

    private bool isDashing = false;         // Flag to track if the object is currently dashing
    private Rigidbody rb;
    private ThirdPersonController controller; // Assuming you have this script

    private Animator animator; // Reference to the Animator component

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    private void Update()
    {
        if (!isDashing)
        {
            if (Input.GetKeyDown(KeyCode.G) && controller.isGrounded)
            {
                dashingUp = true; // Set dashingUp to true when dashing upwards
                Dash(Vector3.up, upwardDashForce, upwardDashDuration);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                dashingForward = true; // Set dashingForward to true when dashing forward
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

        // Trigger the appropriate animations
        animator.SetBool("dashingUp", true);
        animator.SetBool("dashingForward", true);
    }

    private IEnumerator EndDash(float dashDuration)
    {
        // Wait for the specified dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reduce the object's velocity to achieve a controlled slowdown
        rb.velocity *= slowdownFactor;

        // Disable the dashing flags to allow another dash
        isDashing = false;
        dashingUp = false;
        dashingForward = false;

        // Set the animator parameters back to false when the dash ends
        animator.SetBool("dashingUp", false);
        animator.SetBool("dashingForward", false);
    }
}
