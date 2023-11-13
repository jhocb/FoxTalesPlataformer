using UnityEngine;

public class MovimentoUpDown : MonoBehaviour
{
    public float amplitude = 1f;  // Amplitude do movimento
    public float velocidadeMovimento = 2f; // Velocidade do movimento
    public float intervaloDeRotacao = 3f; // Intervalo entre cada rota��o completa
    public float velocidadeRotacao = 360f; // Velocidade de rota��o em graus por segundo

    private Vector3 posicaoInicial; // Posi��o inicial do objeto
    private bool girando = false; // Indica se o objeto est� atualmente girando
    private float tempoInicioGiro; // Momento em que a �ltima rota��o iniciou

    void Start()
    {
        posicaoInicial = transform.position; // Salva a posi��o inicial do objeto
        tempoInicioGiro = Time.time; // Inicializa o tempo de in�cio da �ltima rota��o
    }

    void Update()
    {
        // Movimento alternado para cima e para baixo usando a fun��o seno
        float movimentoVertical = Mathf.Sin(Time.time * velocidadeMovimento) * amplitude;

        // Atualiza a posi��o do objeto
        transform.position = posicaoInicial + new Vector3(0f, movimentoVertical, 0f);

        // Verifica se � hora de come�ar a girar
        if (!girando && Time.time - tempoInicioGiro >= intervaloDeRotacao)
        {
            girando = true;
            tempoInicioGiro = Time.time; // Reinicia o tempo de in�cio da rota��o
        }

        // Se est� girando, aplica a rota��o
        if (girando)
        {
            float anguloRotacao = velocidadeRotacao * Time.deltaTime;

            // Gira uma vez em torno de si mesmo
            transform.Rotate(Vector3.up, anguloRotacao);

            // Se a rota��o completa foi alcan�ada, para de girar
            if (Time.time - tempoInicioGiro >= intervaloDeRotacao)
            {
                girando = false;
            }
        }
    }
}