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
    //Max waves?

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

    public void SpawnWaveOfEnemies()
    {
        int numberOfHeaviesToSpawn = baseNumberOfShips + currentWave/2;

        for (int i = 0; i < numberOfHeaviesToSpawn; i++)
        {
            //rotate the pivot point
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            //instantiate enemy ships at spawn point
            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
            Instantiate(enemyShipPrefabs[0], spawnPoint.position, transform.rotation, null);
        }

        int numberOfArchersToSpawn = baseNumberOfShips + currentWave/6;

        for (int i = 0; i < numberOfArchersToSpawn; i++)
        {
            //rotate the pivot point
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            //instantiate enemy ships at spawn point
            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
            Instantiate(enemyShipPrefabs[1], spawnPoint.position, transform.rotation, null);
        }

    }

    public void CountEnemyShips()
    {
        //Index all ships in game
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        Debug.Log("Number of Enemy Ships: " + currentNumberOfShips);

        if (currentNumberOfShips == 1)
        {
            currentWave++;
            //TODO Update HUD with current wave number
            HUD.Instance.DisplayWave(currentWave);

            SpawnWaveOfEnemies();
            FindObjectOfType<PlayerShip>().ReplenishBombs();
        }

    }
}
