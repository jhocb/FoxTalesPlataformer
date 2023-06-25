using UnityEngine;

public class tutorialCanvas : MonoBehaviour
{
    public GameObject player;
    public GameObject targetObject;
    public GameObject prefab;
    public float activationDistance = 5f;
    public float hoverSpeed = 2f;
    public float hoverHeight = 1f;

    public float yUP;
    public float xPlus;
    public float zPlus;

    private bool isActivated = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, targetObject.transform.position);

        if (distance < activationDistance)
        {
            // Calculate the vertical displacement for hovering
            float yPos = initialPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
            prefab.transform.position = new Vector3(initialPosition.x + xPlus, yPos+yUP, initialPosition.z+zPlus);

            // Make the prefab always face the target object
            prefab.transform.LookAt(targetObject.transform);
        }
        else if (distance >= activationDistance)
        {
           prefab.transform.position = new Vector3(0, 1000, 0);
        }
    }
}
