using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    Transform target;

    public static PowerupSpawner Instance;

    public List<GameObject> powerupPreFabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    public AudioSource boostAudio;

    int baseNumberOfPowerups;
    int currentNumberOfPowerups;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseNumberOfPowerups = 1;
    }

    public void SpawnWaveOfPowerups()
    {
        Debug.Log("Spawn Powerup Wave");

        if (EnemyShipSpawner.Instance.currentWave > 2)
        {
        int numberOfPowerupsToSpawn = Random.Range(1, 5);

        for (int i = 0; i < numberOfPowerupsToSpawn; i++)
        {
            //step 1 rotate Pivot Point aka claw machine arm
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            //step 2 spawn the enemy in the Spawn Point
            int randomPowerUpIndexEasy = Random.Range(0, powerupPreFabs.Count);
            Instantiate(powerupPreFabs[randomPowerUpIndexEasy], spawnPoint.position, transform.rotation, null);
        }
        }
    }
  
}
