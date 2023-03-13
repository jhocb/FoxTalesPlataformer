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

        #region ifs
        if (Input.GetKey("d") || Input.GetKey("a")){

            animator.SetBool("isRunning(wo/ shifht)", true);}
        else{animator.SetBool("isRunning(wo/ shifht)", false);}

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey("d") || Input.GetKey("a"))){

            animator.SetBool("isRunning", true);}
        else{animator.SetBool("isRunning", false);}

        if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.LeftShift) || ((Input.GetKey("d") || Input.GetKey("a"))))){

            animator.SetBool("isJumping", true);}
        else{animator.SetBool("isJumping", false);}

        if (Input.GetKey(KeyCode.Space)){
            animator.SetBool("idleJumping", true);}

        else{animator.SetBool("idleJumping", false);}

        //check if player is in the air
        if(rbM.isGrounded == true)
        {
            animator.SetBool("isGroundeded", true);}
        else{animator.SetBool("isGroundeded", false);}

        if(rbM.atWallL || rbM.atWallR){
            
            animator.SetBool("atWall", true);}
        else{animator.SetBool("atWall", false);}

        if (Input.GetKey(KeyCode.LeftControl) && (Input.GetKey("d") || Input.GetKey("a"))){

            animator.SetBool("isSliding", true);}
        else{animator.SetBool("isSliding", false);}

        if (Input.GetKey("f")){

            animator.SetBool("isFighting", true);}
        else{animator.SetBool("isFighting", false);}

        if (Input.GetKey("x")){
            int variation = Random.Range(0, 2);

        }
        #endregion
    }
}
