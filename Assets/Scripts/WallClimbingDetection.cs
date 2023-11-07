using UnityEngine;

public class WallClimbingDetection : MonoBehaviour
{
    public LayerMask climbableLayer; // A LayerMask para identificar as superfícies escaláveis
    public float climbForce = 10f; // A força de escalada
    private Rigidbody rb;

    private bool isClimbing = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider other)
    {
        if ((climbableLayer & (1 << other.gameObject.layer)) != 0)
        {
            // O jogador está em contato com uma superfície escalável
            isClimbing = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isClimbing = false;
    }

    void Update()
    {
        if (isClimbing)
        {
            // Aplicar uma força para cima para subir
            rb.AddForce(Vector3.up * climbForce);
        }
    }
}
