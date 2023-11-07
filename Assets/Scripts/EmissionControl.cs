using System.Collections;
using UnityEngine;

public class EmissionControl : MonoBehaviour
{
    public Color startEmissionColor = Color.black; // Cor de emissão inicial
    public Color endEmissionColor = Color.red; // Cor de emissão final
    public float changeDuration = 1.0f; // Duração da mudança de cor
    private Material emissiveMaterial;
    private float elapsedTime = 0f;
    private bool isChangingColor = false;

    void Start()
    {
        emissiveMaterial = GetComponent<Renderer>().material;
        emissiveMaterial.EnableKeyword("_EMISSION");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CUBO")) // Substitua "Player" pela tag do seu personagem
        {
            StartCoroutine(ChangeEmissionColor(endEmissionColor));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CUBO")) // Substitua "Player" pela tag do seu personagem
        {
            StartCoroutine(ChangeEmissionColor(startEmissionColor));
        }
    }

    IEnumerator ChangeEmissionColor(Color targetColor)
    {
        if (isChangingColor)
            yield break;

        isChangingColor = true;
        elapsedTime = 0f;
        Color initialColor = emissiveMaterial.GetColor("_EmissionColor");

        while (elapsedTime < changeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / changeDuration;
            Color lerpedColor = Color.Lerp(initialColor, targetColor, t);
            SetEmissionColor(lerpedColor);
            yield return null;
        }

        isChangingColor = false;
    }

    void SetEmissionColor(Color color)
    {
        emissiveMaterial.SetColor("_EmissionColor", color);
    }
}
