using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXInstantiate : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject FirePrefab;

    void Start()
    {
        int randomIndex = Random.Range(0, SpawnPoints.Length);
        Transform selectedSpawnPoint = SpawnPoints[randomIndex];
        Instantiate(FirePrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
    }
}
