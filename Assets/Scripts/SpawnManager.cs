using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    private int enemyCount = 1;
    private int waveCount = 1;
    public GameObject PowerupPrefab;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(waveCount);
        Instantiate(PowerupPrefab, GenerateLocation(), PowerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && !gameOver)
        {
            waveCount++;
            SpawnWave(waveCount);
            Instantiate(PowerupPrefab, GenerateLocation(), PowerupPrefab.transform.rotation);
        }
        int playerCount = GameObject.FindObjectsOfType<PlayerController>().Length;
        if (playerCount == 0)
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }

    private Vector3 GenerateLocation()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }

    void SpawnWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateLocation(), enemyPrefab.transform.rotation);
        }
    }
}
