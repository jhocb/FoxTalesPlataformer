using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaposa : MonoBehaviour
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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
            moveSpeed = 8f;
            isRunning = true;
            //trailVFX.SetActive(true);
        }
        else
        {
            moveSpeed = 4f;
            isRunning = false;
        }
        // Pular
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

    }
}