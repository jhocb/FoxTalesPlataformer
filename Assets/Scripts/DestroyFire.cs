using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    // Este m�todo � chamado quando ocorre um trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidiu com um objeto chamado "CUBO"
        if (other.CompareTag("CUBO"))
        {
            // Destroi o objeto atual
            Destroy(gameObject);
        }
    }
}