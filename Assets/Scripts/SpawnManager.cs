using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9;

    public GameObject[] enemyPrefabs;
    public int enemyCount = 0;
    public int waveNumber = 1;

    public GameObject[] powerupPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        // When all enemies are defeated spawn next wave
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    // Generate a random spawn position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Spawn enemies at random positions
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], GenerateSpawnPosition(), enemyPrefabs[enemyIndex].transform.rotation);
        }

        // Spawn random powerup
        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex], GenerateSpawnPosition(), powerupPrefabs[powerupIndex].transform.rotation);
    }
}
