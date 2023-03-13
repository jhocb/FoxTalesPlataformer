using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControlScript : MonoBehaviour
{
    Animator animator;
    public rigidBodyMovement rbM;
    int randomNumber;

    private bool isFightingBool;
        
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {

        randomNumber = Random.Range(0, 10);
        
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

            animator.SetBool("isFighting", true);
            rbM.fight = 0.15f;
            isFightingBool = true;}

        if (Input.GetKey("g")){

            animator.SetBool("isFighting", false);
            rbM.fight = 1f;
            isFightingBool=false;}

        if (Input.GetKey("x")){

            int variation = Random.Range(0, 3);
            rbM.fight = 0f;

            switch (variation)
            {
                case 0:
                animator.SetInteger("punchVariation", variation);
                animator.SetBool("isPunching", true);
                break;

                case 1:
                animator.SetInteger("punchVariation", variation);
                animator.SetBool("isPunching", true);
                break;

                case 2:
                animator.SetInteger("punchVariation", variation);
                animator.SetBool("isPunching", true);
                break;
            }
            
        }else{animator.SetBool("isPunching", false);}

        if (Input.GetKey("c")){
            
            int variation = Random.Range(0, 3);

            switch (variation)
            {
                case 0:
                animator.SetInteger("kickVariation", variation);
                animator.SetBool("isKicking", true);
                break;

                case 1:
                animator.SetInteger("kickVariation", variation);
                animator.SetBool("isKicking", true);
                break;

                case 2:
                animator.SetInteger("kickVariation", variation);
                animator.SetBool("isKicking", true);
                break;
            }
        }else{animator.SetBool("isKicking", false);}

        if(isFightingBool == true)
        {
            rbM.fight = 0.15f;
            animator.SetInteger("isFightingIdle", randomNumber);
            Debug.Log(randomNumber);
        }
        else{rbM.fight = 1f;}
        #endregion
    }
}