using System.Collections;
using System.Collections.Generic; // We need this for API and LIST functionality
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance;

    public List<GameObject> enemyShipPrefab;
    public Transform pivotPoint;
    public Transform spawnPoint;

    // Data in which is considered by the game

    int currentNumberOfShips;
    int currentWave;
    int baseNumberOfShips;
    // TODO maximum waves, in the case of winning

    private void Awake()
    {
        Instance = this;
        currentWave = 1;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        currentNumberOfShips = baseNumberOfShips;
    }

    public void spawnWaveOfEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        // For loops have 3 parameters
        for(int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // Step 1: Rotate the Pivot Point "claw machine"
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            // Spawn/Instantiate the enemy at/in the Spawn Point
            int randomShipIndex = Random.Range(0, enemyShipPrefab.Count);
            Instantiate(enemyShipPrefab[randomShipIndex], spawnPoint.position, transform.rotation, null);
        }
    }

    public void countEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        
        Debug.Log("Current Number of Enemy Ships: " + currentNumberOfShips); // Print to console for testing purposes

        if(currentNumberOfShips == 1)
        {
            currentWave += 1;

            // TODO Update HUD with current Wave number
            HUD.Instance.DisplayWave(currentWave);

            spawnWaveOfEnemies();
        }
    }
}
