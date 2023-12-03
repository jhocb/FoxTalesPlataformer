using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento3DAtualizado : MonoBehaviour
{
    // Movimento
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody rb;
    public bool isGrounded;
    public bool freeze;
    public bool isGroundedAnim;
    public bool isRunning;
    public bool isWalking;

    // DASH
    // Lado
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    [SerializeField]
    private bool isDashing = false;
    public bool hasUsedSideDash = false;
    public GameObject boxDash;

    // Cima
    [SerializeField]
    public bool hasUsedUpwardDash = false;
    [SerializeField]
    public bool isDashingUp = false;
    public float upwardDashSpeed = 10f;
    public float upwardDashDuration = 0.5f;

    //Animacoes
    public Animator anim;

    //Audios
    public AudioManager audioM;
    public int playerArea;

    //VFX
    //public GameObject trailVFX;
    // Escalada
   //public Transform climbDetection; // Refer�ncia ao objeto de detec��o de colis�es
   //public LayerMask climbableLayer; // A LayerMask para identificar as superf�cies escal�veis
   //public float climbSpeed = 10f; // Velocidade de escalada
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        boxDash = GameObject.Find("TriggerDash");
        audioM = gameObject.GetComponent<AudioManager>();
        playerArea = 1;
    }

    private void Update()
    {
        // Verifique se o personagem est� no ch�o
        int groundLayerMask = 1 << LayerMask.NameToLayer("IgnoreGround");
        int ignoreLayer1 = 1 << LayerMask.NameToLayer("Wall");
        int ignoreLayersMask = ignoreLayer1 | groundLayerMask; // Combina as camadas a serem ignoradas

        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f, ~ignoreLayersMask);

        isGroundedAnim = Physics.Raycast(transform.position, Vector3.down, 0.5f, ~ignoreLayersMask);
        Debug.DrawRay(transform.position, Vector3.down, Color.white);


        // Movimento lateral
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        if (moveDirection != Vector3.zero)
        {
            // Rotacionar o personagem na dire��o do movimento
            isWalking = true;
            transform.forward = moveDirection;
        }
        else
            isWalking = false;
        
        // Aplicar for�a para movimento
        Vector3 moveVelocity = moveDirection * moveSpeed;
        moveVelocity.y = rb.velocity.y; // Manter a componente vertical da velocidade
        rb.velocity = moveVelocity;
        // Correr
        if (isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
            moveSpeed = 8f;
            isRunning = true;
            //trailVFX.SetActive(true);
        }
        else 
        { 
        anim.SetBool("Run", false);
        moveSpeed = 4f;
        isRunning = false;
        }
        // Pular
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("JumpAtt");
            anim.SetBool("isGrounded", false);
        }
        // Dash lateral com um bot�o separado
        if (Input.GetKeyDown(KeyCode.J) && !isDashing && !hasUsedUpwardDash)
        {
            anim.SetTrigger("DashSide");
            Vector3 dashDirection = transform.forward; // Dire��o para a qual o personagem est� olhando
            StartCoroutine(Dash(dashDirection * dashSpeed));
            boxDash.SetActive(true);
            audioM.playDashH();
        }
        // Dash para cima com um bot�o separado
        if (Input.GetKeyDown(KeyCode.K) && !isDashingUp && !hasUsedUpwardDash)
        {
            anim.SetTrigger("DashUp");
            StartCoroutine(UpwardDash(Vector3.up * upwardDashSpeed));
            boxDash.SetActive(true);
            audioM.playDashV();
        }
        /*if (moveDirection != Vector3.zero)
        {
            float rayDistance = 1.0f;
            // Verifique se o jogador est� se movendo na dire��o da parede
            if (Physics.Raycast(transform.position, moveDirection, out RaycastHit hit, rayDistance, climbableLayer))
            {
                Debug.Log("AGARRADO");
                // Inicie a escalada automaticamente
                StartCoroutine(Climb(hit.point, hit.normal));
            }
        }*/
        //Debug.DrawRay(transform.position, moveDirection * climbSpeed * Time.deltaTime, Color.red); // Desenhe o Raycast

        if (isGrounded)
        {
            anim.SetFloat("Velocity", moveVelocity.magnitude);
            hasUsedUpwardDash = false; // Redefinir ao tocar o ch�o
            hasUsedSideDash = false;
        }


        if (isGroundedAnim)
        {
            anim.SetBool("isGrounded", true);
        }
        else
            anim.SetBool("isGrounded", false);

        if(!isDashing && !isDashingUp)
        {
            boxDash.SetActive(false);
        }

    }

    private IEnumerator Dash(Vector3 direction)
    {
        hasUsedUpwardDash = true;
        isDashing = true;
        float startTime = Time.time;

        while (Time.time - startTime < dashDuration)
        {
            rb.velocity = direction;

            yield return null;
        }

        isDashing = false;
        rb.velocity = Vector3.zero;
    }
    private IEnumerator UpwardDash(Vector3 direction)
    {
        hasUsedUpwardDash = true;
        isDashingUp = true;

        float startTime = Time.time;

        while (Time.time - startTime < upwardDashDuration)
        {
            rb.velocity = direction;

            yield return null;
        }
        isDashingUp = false;
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Area1")
        {
            playerArea = 1;
            audioM.UpdateMusic();

        }
        else if(other.name == "Area2")
        {
            playerArea = 2;
            audioM.UpdateMusic();

        }
        else if (other.name == "Area3")
        {
            playerArea = 3;
            audioM.UpdateMusic();

        }
        else if (other.name == "Area4")
        {
            playerArea = 4;
            audioM.UpdateMusic();

        }
    }
    /*private IEnumerator Climb(Vector3 climbPoint, Vector3 wallNormal)
    {
        float startTime = Time.time;

        while (Time.time - startTime < 1f)
        {
            Vector3 climbDirection = (climbPoint - transform.position).normalized;
            rb.velocity = climbDirection * climbSpeed;

            yield return null;
        }

        rb.velocity = Vector3.zero;
    }*/
}