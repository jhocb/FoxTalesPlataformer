using UnityEngine;

public class MovimentoTeste : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
/*{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 100.0f;

    void Update()
    {
        // Movimentação
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize();
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Rotação
        float rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotateInput * rotateSpeed * Time.deltaTime);
    }
}*/
