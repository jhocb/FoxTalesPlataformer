using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControlScript : MonoBehaviour
{
    Animator animator; // reference to the Animator component attached to the same GameObject
    public rigidBodyMovement rbM; // reference to the rigidBodyMovement script attached to another GameObject
    int randomNumber; // variable to hold a random integer value

    private float airTime; // float variable to hold the time the character is in the air

    public bool isFightingBool; // boolean variable to check if the character is fighting
    public bool isPunchingBool; // boolean variable to check if the character is punching
    
    void Start()
    {
        animator = GetComponent<Animator>(); // get the Animator component on this GameObject
        airTime = 0f; // set the 'airTime' float variable to 0f
    }
    
    void Update()
    {
        randomNumber = Random.Range(0, 10); // generate a random integer between 0 and 9
        


        // set animation states based on user input
        // set the 'isRunning(wo/ shifht)' boolean parameter to true if the user is pressing the 'd' or 'a' keys
        animator.SetBool("isRunning(wo/ shifht)", Input.GetKey("d") || Input.GetKey("a")); 
        
        // set the 'isRunning' boolean parameter to true if the user is pressing the 'd' or 'a' keys and the 'LeftShift' key
        animator.SetBool("isRunning", Input.GetKey(KeyCode.LeftShift) && (Input.GetKey("d") || Input.GetKey("a"))); 

        // set the 'isJumping' boolean parameter to true if the user is pressing the 'Space' key and the 'LeftShift' key or the 'd' or 'a' keys
        animator.SetBool("isJumping", Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.LeftShift) || ((Input.GetKey("d") || Input.GetKey("a"))))); 

        // set the 'idleJumping' boolean parameter to true if the user is pressing the 'Space' key
        animator.SetBool("idleJumping", Input.GetKey(KeyCode.Space));

        // set the 'isGrounded' boolean parameter to true if the character is grounded
        animator.SetBool("isGroundeded", rbM.isGrounded);

        // set the 'atWall' boolean parameter to true if the character is at a wall
        animator.SetBool("atWall", rbM.atWallL || rbM.atWallR);

        // set the 'isSliding' boolean parameter to true if the user is pressing the 'LeftControl' key and the 'd' or 'a' keys
        animator.SetBool("isSliding", Input.GetKey(KeyCode.LeftControl) && rbM.slideCooldown <= 0f && (Input.GetKey("d") || Input.GetKey("a")));

        // if the character is in the air, add the time since the last frame to the 'airTime' float variable
        if (rbM.isGrounded == false){ 
            airTime += Time.deltaTime; 
            animator.SetFloat("airTime", airTime);
        }
        else{
            airTime = 0f; // if the character is grounded, set the 'airTime' float variable to 0f
        }






        #region Vi Punching
        // if the character is fighting, punching and in the air, and the user is pressing the 'a' key, set the 'isPunching' boolean parameter to true and add a force to the character
        if(isFightingBool == true && isPunchingBool == true && rbM.isGrounded == false && Input.GetKey("a")){ 

            animator.SetBool("isPunching", true);
            rbM.rb.AddForce(Vector3.left * 30f, ForceMode.Impulse);
        }
        else{
            animator.SetBool("isPunching", false); //set the 'isPunching' boolean parameter to false
        }

        // if the character is fighting, punching and in the air, and the user is pressing the 'd' key, set the 'isPunching' boolean parameter to true and add a force to the character
        if(isFightingBool == true && isPunchingBool == true && rbM.isGrounded == false && Input.GetKey("d")){

            animator.SetBool("isPunching", true); // set the 'isPunching' boolean parameter to true
            rbM.rb.AddForce(Vector3.right * 30f, ForceMode.Impulse); // add a force to the character
        }
        else{
            animator.SetBool("isPunching", false); //set the 'isPunching' boolean parameter to false
        }
        #endregion





         // if the character is in the air and punches, set the 'shoriuken' boolean parameter to true
        if(rbM.isGrounded == false && isFightingBool == true && isPunchingBool == true){

            animator.SetBool("shoriuken", true); // set the 'shoriuken' boolean parameter to true
            rbM.rb.AddForce(Vector3.up * 20f, ForceMode.Impulse); // add a force to the character
        }
        
        if(rbM.isGrounded == true){

            animator.SetBool("shoriuken", false); // set the 'shoriuken' boolean parameter to false
        }





        // handle character fighting animations and actions

        if (Input.GetKeyDown("f"))
        {
            animator.SetBool("isFighting", true); // set the 'isFighting' boolean parameter to true in the Animator
            rbM.fight = 0.15f; // set the 'fight' variable in the rigidBodyMovement script to 0.15f
            isFightingBool = true; // set the 'isFightingBool' boolean variable to true
        }
        else if (Input.GetKeyDown("g"))
        {
            animator.SetBool("isFighting", false); // set the 'isFighting' boolean parameter to false in the Animator
            rbM.fight = 1f; // set the 'fight' variable in the rigidBodyMovement script to 1f
            isFightingBool = false; // set the 'isFightingBool' boolean variable to false
        }
        else if (Input.GetKeyDown("x"))
        {
            int variation = Random.Range(0, 3); // generate a random integer between 0 and 2
            rbM.fight = 0f; // set the 'fight' variable in the rigidBodyMovement script to 0f
            animator.SetInteger("punchVariation", variation); // set the 'punchVariation' integer parameter in the Animator to the generated value
            animator.SetBool("isPunching", true); // set the 'isPunching' boolean parameter in the Animator to true
            isPunchingBool = true; // set the 'isPunchingBool' boolean variable to true
        }
        else
        {
            animator.SetBool("isPunching", false); // set the 'isPunching' boolean parameter in the Animator to false
            isPunchingBool = false; // set the 'isPunchingBool' boolean variable to false
        }

        if (Input.GetKeyDown("c"))
        {
            int variation = Random.Range(0, 3); // generate a random integer between 0 and 2
            animator.SetInteger("kickVariation", variation); // set the 'kickVariation' integer parameter in the Animator to the generated value
            animator.SetBool("isKicking", true); // set the 'isKicking' boolean parameter in the Animator to true
        }
        else
        {
            animator.SetBool("isKicking", false); // set the 'isKicking' boolean parameter in the Animator to false
        }

        if (isFightingBool) // check if character is fighting
        {
            rbM.fight = 0.15f; // if the character is fighting, lower its movement speed
            animator.SetInteger("isFightingIdle", randomNumber); // set the 'isFightingIdle' integer parameter in the Animator to the generated random integer
        }
        else
        {
            rbM.fight = 1f; // if the character is not fighting, set its movement speed to normal
        }
    }
}