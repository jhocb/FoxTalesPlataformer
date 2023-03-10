using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControlScript : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("a")){

            animator.SetBool("isRunning(wo/ shifht)", true);
        }

        if (!Input.GetKey("d") && !Input.GetKey("a")){

            animator.SetBool("isRunning(wo/ shifht)", false);
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey("d") || Input.GetKey("a"))){

            animator.SetBool("isRunning", true);
        }

        if (!Input.GetKey(KeyCode.LeftShift)){

            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.Space)){

            animator.SetBool("isJumping", true);
        }

        if (!Input.GetKey(KeyCode.Space)){

            animator.SetBool("isJumping", false);
        }


    }
}
