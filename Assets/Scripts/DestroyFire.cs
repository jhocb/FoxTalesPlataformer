using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    // Este método é chamado quando ocorre um trigger
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