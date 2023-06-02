using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXInstantiate : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject FirePrefab;

    void Start()
    {
        int[] SpawnPoints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Transform selectedSpawnPoint = SpawnPoints[(int)Random.Range(0, SpawnPoints.Count - 1)];
        Instantiate(FirePrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
    }
}
