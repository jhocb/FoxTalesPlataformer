using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class libraryRotation : MonoBehaviour
{
    public float speed = 0.5f; // Adjust this to control the speed of the object.

    private void Update()
    {
        // Move the object down along the Y-axis.
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
