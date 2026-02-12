using JetBrains.Annotations;
using UnityEngine;
using System.Collections.Generic;

public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance;

    public List<GameObject> enemyShipPrefabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    int currentNumberOfShips;
    int currentWave;
    int baseNumberOfShips;



    private void Awake()
    {
        Instance = this;
        currentWave = 1;
    }


    void Start()
    {
        baseNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        currentNumberOfShips = baseNumberOfShips;
    }

    private void Update()
    {
        
    }
    public void SpawnWaveofEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        for(int i = 0; i< numberOfEnemiesToSpawn; i++)
        {
            // Step 1: Rotate the claw machine arm 
            float newZRotation = Random.Range(0, 360);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            //Step 2: Spawn/Instantiate the enemy in the spawn point
            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
            Instantiate(enemyShipPrefabs[0], spawnPoint.position, transform.rotation, null);
        }
    }

    public void CountEnemyShips()
    {
         currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips);

        if (currentNumberOfShips == 1)
        {
            currentWave++;
            //TODO Update HUD with current wave number

            HUD.Instance.DisplayWave(currentWave);
            SpawnWaveofEnemies();
        }
    }

}
