using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public static PowerupSpawner Instance;

    public List<GameObject> powerupPreFabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    int baseNumberOfPowerups;
    int currentNumberOfPowerups;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseNumberOfPowerups = FindObjectsByType<PowerUp>(FindObjectsSortMode.None).Length;
        currentNumberOfPowerups = baseNumberOfPowerups;
    }

    public void SpawnWaveOfPowerups()
    {
        int numberOfPowerupsToSpawn = baseNumberOfPowerups + 1;

        for (int i = 0; i < numberOfPowerupsToSpawn; i++)
        {
            //step 1 rotate Pivot Point aka claw machine arm
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            //step 2 spawn the enemy in the Spawn Point
            int randomShipIndex = Random.Range(0, powerupPreFabs.Count);
            Instantiate(powerupPreFabs[randomShipIndex], spawnPoint.position, transform.rotation, null);
        }
       
        InvokeRepeating("CountPowerups", 0, 1); 
    }
    public void CountEnemyShips()
    {
        currentNumberOfPowerups = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Powerups: " + currentNumberOfPowerups); //this will print to console so we can test

        if (currentNumberOfPowerups == 0)
        {
            SpawnWaveOfPowerups();
        }
    }
}
