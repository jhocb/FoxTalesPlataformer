using System.Collections;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;
    public float countdown = 5; // Defina o tempo desejado em segundos

    Vector3 initialPosition; // Guarda a posição inicial da plataforma

    void Start()
    {
        // Armazena a posição inicial ao iniciar o jogo
        initialPosition = transform.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "PlaceholderChar")
        {
            StartCoroutine(StartFallingCountdown());
        }
    }

    IEnumerator StartFallingCountdown()
    {
        yield return new WaitForSeconds(countdown);
        isFalling = true;
        yield return new WaitForSeconds(5); // Tempo de espera antes de reciclar
        RecyclePlatform();
    }

    void Update()
    {
        if (isFalling)
        {
            downSpeed += Time.deltaTime / 10;
            transform.position = new Vector3(transform.position.x,
                transform.position.y - downSpeed,
                transform.position.z);
        }
    }

    void RecyclePlatform()
    {
        isFalling = false;
        downSpeed = 0;

        // Ativa o objeto original
        gameObject.SetActive(true);

        // Reposiciona o objeto original para a posição inicial
        transform.position = initialPosition;
    }
}
