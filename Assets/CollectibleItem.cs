using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public GameObject iconPrefab;
    public GameObject Player;
    public KeyCode interactionKey = KeyCode.E;

    private GameObject iconInstance;
    private bool canInteract;
    public Vector3 anchor;

    public float height;
    public float distance;


    private void Start()
    {
        anchor = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        // Instancia o �cone acima do objeto, desativado inicialmente
        iconInstance = Instantiate(iconPrefab, anchor, Quaternion.identity, gameObject.transform);
        iconInstance.SetActive(false);
    }

    private void Update() {
        distance = Vector3.Distance(transform.position, Player.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador entrou no alcance do objeto
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            iconInstance.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o jogador saiu do alcance do objeto
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            iconInstance.SetActive(false);
        }
    }
}
