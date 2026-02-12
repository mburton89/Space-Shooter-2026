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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        currentNumberOfShips = baseNumberOfShips;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWaveOfEnemies()
    {

    }

    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of current enemy ships: " + currentNumberOfShips);

        if(currentNumberOfShips == 1)
        {
            currentWave++;
            //TODO: Update HUD with current wave number
            SpawnWaveOfEnemies();
        }
    }
}
