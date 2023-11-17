using UnityEngine;

public class MovimentoUpDown : MonoBehaviour
{
    public float amplitude = 1f;  // Amplitude do movimento
    public float velocidadeMovimento = 2f; // Velocidade do movimento
    public float intervaloDeRotacao = 3f; // Intervalo entre cada rotação completa
    public float velocidadeRotacao = 360f; // Velocidade de rotação em graus por segundo

    private Vector3 posicaoInicial; // Posição inicial do objeto
    private bool girando = false; // Indica se o objeto está atualmente girando
    private float tempoInicioGiro; // Momento em que a última rotação iniciou

    void Start()
    {
        posicaoInicial = transform.position; // Salva a posição inicial do objeto
        tempoInicioGiro = Time.time; // Inicializa o tempo de início da última rotação
    }

    void Update()
    {
        // Movimento alternado para cima e para baixo usando a função seno
        float movimentoVertical = Mathf.Sin(Time.time * velocidadeMovimento) * amplitude;

        // Atualiza a posição do objeto
        transform.position = posicaoInicial + new Vector3(0f, movimentoVertical, 0f);

        // Verifica se é hora de começar a girar
        if (!girando && Time.time - tempoInicioGiro >= intervaloDeRotacao)
        {
            girando = true;
            tempoInicioGiro = Time.time; // Reinicia o tempo de início da rotação
        }

        // Se está girando, aplica a rotação
        if (girando)
        {
            float anguloRotacao = velocidadeRotacao * Time.deltaTime;

            // Gira uma vez em torno de si mesmo
            transform.Rotate(Vector3.up, anguloRotacao);

            // Se a rotação completa foi alcançada, para de girar
            if (Time.time - tempoInicioGiro >= intervaloDeRotacao)
            {
                girando = false;
            }
        }
    }
}