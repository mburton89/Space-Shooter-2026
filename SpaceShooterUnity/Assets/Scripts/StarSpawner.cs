using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public float maxX;
    public float maxY;
    public float minZ;
    public float maxZ;

    public int numberOfStarsToSpawn;
    public int numberOfShineStarsToSpawn;

    public GameObject shineStar;
    public GameObject star;

    void Start()
    {
        SpawnStars();
        SpawnShineStars();
    }

    void SpawnStars()
    {
        for (int i = 0; i < numberOfStarsToSpawn; i++)
        {
            float randX = Random.Range(-maxX, maxX);
            float randY = Random.Range(-maxY, maxY);
            float randZ = Random.Range(minZ, maxZ);
        
            Vector3 spawnPosition = new Vector3(randX, randY, randZ);

            Instantiate(star, spawnPosition, Quaternion.identity, transform);
        }
    }

    void SpawnShineStars()
    {
        for (int i = 0; i < numberOfShineStarsToSpawn; i++)
        {
            float randX = Random.Range(-maxX, maxX);
            float randY = Random.Range(-maxY, maxY);
            float randZ = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(randX, randY, randZ);

            Instantiate(shineStar, spawnPosition, Quaternion.identity, transform);
        }
    }
}
