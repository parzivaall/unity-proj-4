using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, new Vector3(0, 0, 6), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(enemyPrefab, GenerateLocation(), Quaternion.identity);
    }

    private Vector3 GenerateLocation()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
}
