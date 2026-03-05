using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public float maxX;
    public float maxY;
    public float minZ;
    public float maxZ;

    public int numberOfPowerUpsToSpawn;

    public GameObject Health;

    void Start()
    {
        SpawnHealth();
    }

    void SpawnHealth()
    {
        for (int i = 0; i < numberOfPowerUpsToSpawn; i++)
        {
            float randX = Random.Range(-maxX, maxX);
            float randY = Random.Range(-maxY, maxY);
            float randZ = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(randX, randY, randZ);

            Instantiate(Health, spawnPosition, Quaternion.identity, transform);
        }
    }
}
