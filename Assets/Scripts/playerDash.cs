using UnityEngine;
using System.Collections;
using Climbing;

public class playerDash : MonoBehaviour
{
    public float upwardDashForce = 10f;
    public float horizontalDashForce = 10f;
    public float upwardDashDuration = 0.2f;
    public float horizontalDashDuration = 0.2f;
    public float slowdownFactor = 0.5f;

    private bool isDashing = false;
    private bool dashingUp = false; 
    private bool dashingForward = false;
    private Rigidbody rb;
    private ThirdPersonController controller;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isDashing)
        {
            if (Input.GetKeyDown(KeyCode.G) && controller.isGrounded)
            {
                dashingUp = true;
                Dash(Vector3.up, upwardDashForce, upwardDashDuration);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                dashingForward = true;
                Dash(transform.forward, horizontalDashForce, horizontalDashDuration);
            }
        }
    }

    private void Dash(Vector3 dashDirection, float dashForce, float dashDuration)
    {
        isDashing = true;
        rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
        StartCoroutine(EndDash(dashDuration));
        //Debug.Log("Dashing");
        animator.SetBool("dashing",isDashing);
        animator.SetBool("dashingUp", dashingUp);
        animator.SetBool("dashingFoward", dashingForward);
    }

    private IEnumerator EndDash(float dashDuration)
    {
        yield return new WaitForSeconds(dashDuration);
        rb.velocity *= slowdownFactor;
        isDashing = false;
        dashingUp = false;
        dashingForward = false;
        animator.SetBool("dashing",false);
        animator.SetBool("dashingUp", false);
        animator.SetBool("dashingFoward", false);
    }
}
