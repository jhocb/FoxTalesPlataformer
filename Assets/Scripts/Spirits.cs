using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirits : MonoBehaviour
{

    public float speed = 0.1f;
    public float destroyDelay = 0.1f;
    public float erodeRate = 0.03f;
    public float erodeRefreshRate = 0.01f;
    public float erodeDelay = 0.5f;
    public SkinnedMeshRenderer skmR;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ErodeObject());

        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ErodeObject()
    {
        yield return new WaitForSeconds(erodeDelay);

        float t = 0;
        while (t < 1)
        {
            t += erodeRate;
            skmR.material.SetFloat("_Erode", t);
            yield return new WaitForSeconds(erodeRefreshRate);
        }
    }


}
