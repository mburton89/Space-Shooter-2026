using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashPlanetSpawner : MonoBehaviour
{
    public float maxX;
    public float maxY;
    public float minZ;
    public float maxZ;

    public int numberOfCrashPlanetsToSpawn;
    public int damageToGive;

    public GameObject planet;

    void Start()
    {
        SpawnCrashPlanets();
    }

    void SpawnCrashPlanets()
    {
        for (int i = 0; i < numberOfCrashPlanetsToSpawn; i++)
        {
            float randX = Random.Range(-maxX, maxX);
            float randY = Random.Range(-maxY, maxY);
            float randZ = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(randX, randY, randZ);

            Instantiate(planet, spawnPosition, Quaternion.identity, transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we made it this far, we collided with SOMETHING

        if (collision.GetComponent<Ship>())
        {
            collision.GetComponent<Ship>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }
    }
}
