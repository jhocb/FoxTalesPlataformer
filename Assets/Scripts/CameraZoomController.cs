using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{

    public GameObject followerFocus;
    public cameraFollow cameraFollow;
    public float originalZ;
    public float newZ;
    public float originalY;
    public float newY;
    public Vector3 originalRotation;
    public Vector3 newRotation;
    // Start is called before the first frame update
    void Start()
    {
        followerFocus = GameObject.Find("followerFocus");
        cameraFollow = GameObject.Find("followerFocus").GetComponent<cameraFollow>();


        originalZ = cameraFollow.distanceZ;
        originalZ = cameraFollow.distanceY;

        originalRotation = followerFocus.transform.rotation.eulerAngles;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CUBO"))
        {
            cameraFollow.distanceZ = newZ;
            cameraFollow.distanceZ = newY;

            // Crie uma nova instância de Quaternion com os valores de rotação desejados
            Quaternion newRotationQuaternion = Quaternion.Euler(newRotation);

            // Atribua a nova instância de Quaternion à rotação do objeto
            followerFocus.transform.rotation = newRotationQuaternion;
        }
        /*else
        {
            cameraFollow.distanceZ = originalZ;
            // Crie uma nova instância de Quaternion com os valores de rotação desejados
            Quaternion newRotationQuaternion = Quaternion.Euler(originalRotation);

            // Atribua a nova instância de Quaternion à rotação do objeto
            followerFocus.transform.rotation = newRotationQuaternion;
        }*/
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CUBO"))
        {
            cameraFollow.distanceZ = originalZ;
            cameraFollow.distanceZ = originalY;

            // Crie uma nova instância de Quaternion com os valores de rotação desejados
            Quaternion newRotationQuaternion = Quaternion.Euler(originalRotation);

            // Atribua a nova instância de Quaternion à rotação do objeto
            followerFocus.transform.rotation = newRotationQuaternion;
        }
    }


}
