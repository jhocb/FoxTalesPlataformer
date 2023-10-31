using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movimento3DAtualizado : MonoBehaviour
{
    private Transform characterTransform;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity = -9.81f;
    private CharacterController characterController;
    private Vector3 moveDirection;
    float horizontalInput;
    float verticalInput;


    //EDGE GRAB
    public float raycastDistance = 1.5f;
    private bool isGrabbingEdge = false;


    //DASH
    public float dashSpeed = 10f;
    public float dashVerticalSpeed = 10f;
    public float dashDuration = 0.2f;
    private bool isDashing = false;
    private Vector3 dashDirection;
    private float dashTime;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterTransform = transform;
    }

    void Update()
    {

        //MOVIMENTO
        // Verifique se o personagem está no chão
        if (characterController.isGrounded)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
            moveDirection = move * moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }





        // Aplicar a gravidade
        moveDirection.y += gravity * Time.deltaTime;

        // Mover o personagem
        characterController.Move(moveDirection * Time.deltaTime);


        //GRAB EDGE
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, raycastDistance))
        {
            // Verifique se a superfície é adequada para agarrar (por exemplo, tag "Edge" para as arestas).
            if (hit.collider.CompareTag("Edge") && Input.GetKeyDown(KeyCode.Space))
            {
                isGrabbingEdge = true;
                // Implemente a lógica para agarrar a aresta aqui.
            }
        }

        if (isGrabbingEdge)
        {
            moveDirection.y = 0f;
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");
            // Implemente a lógica para o personagem agarrar na aresta e subir ou descer.
        }


        //DASHS
        //VERTICAL
        if (Input.GetKeyDown(KeyCode.J) && !isDashing)
        {
            isDashing = true;
            dashDirection = transform.forward;  // Por exemplo, você pode fazer o dash para frente.
            dashTime = Time.time + dashDuration;
        }
        //HORIZONTAL
        if (Input.GetKeyDown(KeyCode.L) && !isDashing)
        {
            isDashing = true;
            dashDirection = Vector3.up;  // Ou outra direção vertical desejada.
            dashTime = Time.time + dashDuration;
        }
        //VERIFICAR ESTADO E APLICAR A VELOCIDADE
        if (isDashing && Time.time < dashTime)
        {
            characterController.Move(dashDirection * dashSpeed * Time.deltaTime);
        }
        else
        {
            isDashing = false;
        }
    }
}
