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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && (atWallL == false) && (atWallR == false))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            atWallL = false;
            atWallR = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && atWallL)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            rb.AddForce(Vector3.right * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            atWallL = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && atWallR)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            rb.AddForce(Vector3.left * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            atWallR = false;
        }
    }

    //to check if the player is grounded
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wallL"))
        {
            atWallL = true;
        }

        if (collision.gameObject.CompareTag("wallR"))
        {
            atWallR = true;
        }
       
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("wallR") || collision.gameObject.CompareTag("wallL"))
        {
            isGrounded = true;
        }
    }
}

