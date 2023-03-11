using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritsSummon : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float fireRate = 4f;

    //private Vector3 destination;
    private float timeToFire;
    private Spirits spiritsScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        InstantiateProjectileAtFirePoint();
    }

    
    void InstantiateProjectileAtFirePoint() 
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;

        spiritsScript = projectile.GetComponent<Spirits>();
        projectileObj.GetComponent<Rigidbody>().velocity = firePoint.transform.forward * spiritsScript.speed;

    }

}
