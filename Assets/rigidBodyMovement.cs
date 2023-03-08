using UnityEngine;

public class rigidBodyMovement : MonoBehaviour
{

    //starting the public variables for the movement
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float slideSpeed = 3f;
    public float jumpNormal = 10f;
    public float jumpSlide = 15f;
    
    private Rigidbody rb;
    public bool isGrounded = true;
    public bool atWallL = false;
    public bool atWallR = false;
    public bool jumpable = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        //starting the horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //disabled the vertical movement for now
        //float verticalInput = Input.GetAxis("Vertical");

        //to check if the player is grounded, if he is in the air, he cant sprint
        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            currentSpeed = runSpeed;
        }

         //if the player is sliding, he can jump higher
        float jumpHeight = jumpNormal;
        if (Input.GetKey(KeyCode.LeftControl) && isGrounded)
        {
            jumpHeight = jumpSlide;
            currentSpeed = slideSpeed;
        }

        //the line below considers the vertical movement, wich is disabled for now
        //Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * currentSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

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

        //base code for the jump, but in wall, it adds a force to the opposite side of the wall
        if (Input.GetKeyDown(KeyCode.Space) && atWallL && jumpable)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            rb.AddForce(Vector3.right * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            atWallL = false;
            jumpable = false;
        }

        //base code for the jump, but in wall, it adds a force to the opposite side of the wall
        if (Input.GetKeyDown(KeyCode.Space) && atWallR && jumpable)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            rb.AddForce(Vector3.left * jumpHeight, ForceMode.Impulse);
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

