using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonRotator : MonoBehaviour
{
    public GameObject moonEmptyRotator; // this is the empty object that is the parent of the moon
    public float velocity = 0.25f; // this is the speed of the rotation

    // Update is called once per frame
    void FixedUpdate()
    {
       moonEmptyRotator.transform.Rotate(0.125f * velocity, 0.05f * velocity, 0.175f * velocity, Space.World); // this is the rotation of the moon
    }
}
