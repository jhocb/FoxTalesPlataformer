using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento3DAtualizado : MonoBehaviour
{
    // Movimento
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    public bool isGrounded;
    public bool freeze;

    // DASH
    // Lado
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    [SerializeField]
    private bool isDashing = false;

    // Cima
    [SerializeField]
    public bool hasUsedUpwardDash = false;
    [SerializeField]
    public bool isDashingUp = false;
    public float upwardDashSpeed = 10f;
    public float upwardDashDuration = 0.5f;

    //Animacoes
    public Animator anim;
    // Escalada
   //public Transform climbDetection; // Referência ao objeto de detecção de colisões
   //public LayerMask climbableLayer; // A LayerMask para identificar as superfícies escaláveis
   //public float climbSpeed = 10f; // Velocidade de escalada
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Verifique se o personagem está no chão
        int groundLayerMask = 1 << LayerMask.NameToLayer("IgnoreGround");
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f, ~groundLayerMask);
        Debug.DrawRay(transform.position, Vector3.down, Color.green, 0.5f);

        // Movimento lateral
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        if (moveDirection != Vector3.zero)
        {
            // Rotacionar o personagem na direção do movimento
            transform.forward = moveDirection;
        }
        // Aplicar força para movimento
        Vector3 moveVelocity = moveDirection * moveSpeed;
        moveVelocity.y = rb.velocity.y; // Manter a componente vertical da velocidade
        rb.velocity = moveVelocity;
        // Correr
        if (isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
            moveSpeed = 8f;
        }
        else 
        { 
        anim.SetBool("Run", false);
        moveSpeed = 5f;
        }
        // Pular
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetBool("Jump", true);

        }
        // Dash lateral com um botão separado
        if (Input.GetKeyDown(KeyCode.J) && !isDashing && !hasUsedUpwardDash)
        {
            anim.SetTrigger("DashSide");
            Vector3 dashDirection = transform.forward; // Direção para a qual o personagem está olhando
            StartCoroutine(Dash(dashDirection * dashSpeed));
        }
        // Dash para cima com um botão separado
        if (Input.GetKeyDown(KeyCode.L) && !isDashingUp && !hasUsedUpwardDash)
        {
            anim.SetTrigger("DashUp");
            StartCoroutine(UpwardDash(Vector3.up * upwardDashSpeed));
        }
        /*if (moveDirection != Vector3.zero)
        {
            float rayDistance = 1.0f;
            // Verifique se o jogador está se movendo na direção da parede
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
            hasUsedUpwardDash = false; // Redefinir ao tocar o chão
        }


    }

    private IEnumerator Dash(Vector3 direction)
    {
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