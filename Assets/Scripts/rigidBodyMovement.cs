using UnityEngine;

public class rigidBodyMovement : MonoBehaviour
{

    //starting the public variables for the movement
    #region Floats
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float slideSpeed = 3f;
    public float jumpNormal = 10f;
    public float jumpSlide = 15f;
    public float wallJumpUp = 5f;
    public float wallJumpSide = 2f;
    #endregion
    
    
    //starting the rigidbody
    private Rigidbody rb;
    
    //flags for the jump system
    public bool isGrounded = true;
    public bool atWallL = false;
    public bool atWallR = false;
    public bool jumpable = true;

    //variable to turn the character in the direction its going
    public float rotationSpeed;

    //variables for the slow down while sliding
    //drag is the rigidbody component drag
    //dragger is how much you will slow down per update
    private float drag;
    public float dragger = 0.005f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        drag = rb.drag;
    }

    void FixedUpdate()
    {
        //starting the horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //disabled the vertical movement for now
        //float verticalInput = Input.GetAxis("Vertical");

        //to check if the player is grounded, if he is in the air, he cant sprint
        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }

         //if the player is sliding, he can jump higher, gonna change the
         //jumpheight value inside the ifs for shift and control keys
        float jumpHeight = jumpNormal;

        if (Input.GetKey(KeyCode.LeftControl) && isGrounded)
        {
            jumpHeight = jumpSlide;
            currentSpeed = slideSpeed;

            //subtracting the drag value, gonna multiply it later
            //which will make the value for the movement go to zero
            drag -= dragger;

            //when drag hits zero, im stopping the subtraciton, if i dont
            //the value will become negative, which will push the player to the opposite side
            if(drag <= 0.01)
            {
                dragger = 0;
            }
        }
        else
        {
            drag = 1;
            dragger = 0.005f;
        }

        //the line below considers the vertical movement, wich is disabled for now
        //Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * currentSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + (movement*drag));
        movement.Normalize();

        //to check if the player is grounded, if he is, than he can jump, we need to change this for double jump in the future
        //in case we want to implement it
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && (atWallL == false) && (atWallR == false) && jumpable)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            atWallL = false;
            atWallR = false;
            jumpable = false;
        }

        //rotates the player in the direction its going
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }

        //base code for the jump, but in wall, it adds a force to the opposite side of the wall
        if (Input.GetKeyDown(KeyCode.Space) && atWallL && jumpable)
        {
            rb.AddForce(Vector3.up * jumpHeight* wallJumpUp, ForceMode.Impulse);
            rb.AddForce(Vector3.right * jumpHeight* wallJumpSide, ForceMode.Impulse);
            isGrounded = false;
            atWallL = false;
            jumpable = false;
        }

        //base code for the jump, but in wall, it adds a force to the opposite side of the wall
        if (Input.GetKeyDown(KeyCode.Space) && atWallR && jumpable)
        {
            rb.AddForce(Vector3.up * jumpHeight* wallJumpUp, ForceMode.Impulse);
            rb.AddForce(Vector3.left * jumpHeight* wallJumpSide, ForceMode.Impulse);
            isGrounded = false;
            atWallR = false;
            jumpable = false;
        }
    }

    //to check if the player is grounded or at wall 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wallL"))
        {
            atWallL = true;
            jumpable = true;
        }

        if (collision.gameObject.CompareTag("wallR"))
        {
            atWallR = true;
            jumpable = true;
        }
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpable = true;
            atWallL = false;
            atWallR = false;
        }
    }

    //disable the the flags, sometimes when leaving a surface without jumping, they would still
    //be turned on, which would make you jump kinda weird until you normal jumped
    void OnCollisionExit(Collision collision) {

        if (collision.gameObject.CompareTag("wallL"))
        {
            atWallL = false;
            jumpable = false;
        }

        if (collision.gameObject.CompareTag("wallR"))
        {
            atWallR = false;
            jumpable = false;
        }
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            jumpable = false;
            atWallL = false;
            atWallR = false;
        }
        
    }
}

