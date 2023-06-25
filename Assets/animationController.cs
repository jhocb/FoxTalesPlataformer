using UnityEngine;

public class animationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Set the "punching" parameter in the Animator controller to true
            animator.SetBool("punching", true);
        }
        else{
            animator.SetBool("punching", false);
        }
    }
}