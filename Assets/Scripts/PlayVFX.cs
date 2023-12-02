using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVFX : MonoBehaviour
{
    public ParticleSystem thisParticle;
    public int destroyDelay;
    // Start is called before the first frame update
    void Start()
    {
        thisParticle.Play();
        Destroy(gameObject, destroyDelay);

    }


}
