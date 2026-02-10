using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public float maxX;
    public float maxY;
    public float minZ;
    public float maxZ;

    public int numberOfPlanetsToSpawn;

    public GameObject planet;

    void Start()
    {
        SpawnPlanets();
    }

    void SpawnPlanets()
    {
        for (int i = 0; i < numberOfPlanetsToSpawn; i++)
        {
            float randX = Random.Range(-maxX, maxX);
            float randY = Random.Range(-maxY, maxY);
            float randZ = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(randX, randY, randZ);

            Instantiate(planet, spawnPosition, Quaternion.identity, transform);
        }
    }
}
