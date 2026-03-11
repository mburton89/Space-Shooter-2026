
using UnityEngine;
using System.Collections.Generic;


public class HealthSpawner : MonoBehaviour
{
    public static HealthSpawner Instance;

    public List<GameObject> powerUpPrefabs;
    public Transform pivotPointTwo;
    public Transform spawnPointTwo;

    int currentNumberOfPowerups;
    int currentWave;
    int baseNumberOfPowerups;

    private void Awake()
    {
        Instance = this;
        currentWave = 1;
    }

    void Start()
    {
        baseNumberOfPowerups = FindObjectsByType<HealPowerUp>(FindObjectsSortMode.None).Length;
        currentNumberOfPowerups = baseNumberOfPowerups;

        InvokeRepeating("CountEnemyShips", 0, 1);
    }

    public void SpawnWaveOfPowerups()
    {
        int numberOfPowerupsToSpawn = baseNumberOfPowerups + currentWave - 1;

        for (int i = 0; i < numberOfPowerupsToSpawn; i++)
        {
            //Step 1: rotate pivot poin (claw arm)
            float newZRotation = Random.Range(0f, 360f);
            pivotPointTwo.eulerAngles = new Vector3(0, 0, newZRotation);

            //step 2: Spawn/Instantiate the enemy in the spawn point 
            int randomShipIndex = Random.Range(0, powerUpPrefabs.Count);
            Instantiate(powerUpPrefabs[randomShipIndex], spawnPointTwo.position, transform.rotation, null);
        }

    }

    public void CountEnemyShips()
    {
        currentNumberOfPowerups = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Powerups: " + currentNumberOfPowerups); //this will print to console so we can test

        if (currentNumberOfPowerups == 0)
        {
            currentWave += 1;



            HUD.Instance.DisplayWave(currentWave); //TODO Update HUD with current wave number
            SpawnWaveOfPowerups();


        }
    }

    public void CountPowerups()
    {
        currentNumberOfPowerups = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfPowerups); //this will print to console so we can test

        if (currentNumberOfPowerups == 0)
        {
            currentWave += 1;
        }
    }
}