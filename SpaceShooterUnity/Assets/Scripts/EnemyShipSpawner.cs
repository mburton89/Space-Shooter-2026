using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;  // we need this API for LIST functionality

public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance;

    public List<GameObject> enemyShipPrefabs;
    public Transform pivotPoint;
    public Transform spawnPoint;


    int currentNumberOfShips;
    int currentWave;
    int baseNumberofShips;
    // TODO max waves if we want to "beat" the game

    private void Awake()
    {
        Instance = this;
        currentWave = 1;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseNumberofShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        currentNumberOfShips = baseNumberofShips;
        HUD.Instance.DisplayHighestWave(PlayerPrefs.GetInt("HighestWave"));

    }
    public void SpawnWaveOfEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberofShips + currentWave - 1;

        for(int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            //Rotate the claw machine arm
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);
            //Spawn Instantiate the enemy at the Spawn Point
            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
            Instantiate(enemyShipPrefabs[randomShipIndex], spawnPoint.position, transform.rotation, null);
        }
    }
    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips); // this will print to console so we can test

        if(currentNumberOfShips == 1)
        {
            currentWave++;
            //TODO Update HUD with current wave number
            HUD.Instance.DisplayWave(currentWave);

            SpawnWaveOfEnemies();

            int highestWaveAchieved = PlayerPrefs.GetInt("HighestWave");

            if (currentWave > highestWaveAchieved)
            {
                //YOU SET A NEW HIGHSCORE / WAVE
                PlayerPrefs.SetInt("HighestWave", currentWave);
                HUD.Instance.DisplayHighestWave(currentWave);
            }
        }
    }
}
