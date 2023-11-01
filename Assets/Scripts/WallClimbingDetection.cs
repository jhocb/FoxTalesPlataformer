using UnityEngine;

public class WallClimbingDetection : MonoBehaviour
{
    public LayerMask climbableLayer; // A LayerMask para identificar as superf�cies escal�veis
    public float climbForce = 10f; // A for�a de escalada
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
            // O jogador est� em contato com uma superf�cie escal�vel
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
            // Aplicar uma for�a para cima para subir
            rb.AddForce(Vector3.up * climbForce);
        }
    }
}
