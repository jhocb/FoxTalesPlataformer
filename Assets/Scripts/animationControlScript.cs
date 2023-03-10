using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControlScript : MonoBehaviour
{

    Animator animator;
    public rigidBodyMovement rbM;
   

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

        if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.LeftShift) || ((Input.GetKey("d") || Input.GetKey("a"))))){

            animator.SetBool("isJumping", true);
        }

        if (!Input.GetKey(KeyCode.Space)){

            animator.SetBool("isJumping", false);
        }

        if (Input.GetKey(KeyCode.Space)){
            animator.SetBool("idleJumping", true);
        }

        if (!Input.GetKey(KeyCode.Space)){
            animator.SetBool("idleJumping", false);
        }

        //check if player is in the air
        if(rbM.isGrounded == true)
        {
            animator.SetBool("isGroundeded", true);
        }
        if(rbM.isGrounded == false)
        {
            animator.SetBool("isGroundeded", false);
        }

        if(rbM.atWallL || rbM.atWallR){
            
            animator.SetBool("atWall", true);
        }

        if(!rbM.atWallL && !rbM.atWallR){
            
            animator.SetBool("atWall", false);
        }


    }
}
