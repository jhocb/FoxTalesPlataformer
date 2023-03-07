using UnityEngine;

public class rigidBodyMovement : MonoBehaviour
{

    //starting the public variables for the movement
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 10f;
    
    private Rigidbody rb;
    public bool isGrounded = true;

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

        //the line below considers the vertical movement, wich is disabled for now
        //Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * currentSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        //to check if the player is grounded, if he is, than he can jump, we need to change this for double jump in the future
        //in case we want to implement it
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    //to check if the player is grounded
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

