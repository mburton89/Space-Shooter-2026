using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic; //We need this API for LIST functionality

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public List<GameObject> enemyShipPrefab;
    public Transform pivotPoint;
    public Transform spawnPoint;

    int currentNumberOfShips;
    int currentWave;
    int baseNumberOfShips;
    //TODO max waves if we want to "beat" the game

    private void Awake()
    {
        Instance = this;
        currentWave = 1;
    }
    void Start()
    {
        baseNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        currentNumberOfShips = baseNumberOfShips;
        HUD.Instance.DisplayHighestWave(PlayerPrefs.GetInt("HighestRound"));
    }

    public void SpawnWaveOfEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        for(int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            //Step 1: Rotate the Pivot Point
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);
            
            //Step 2: Spawn the enemy in the spawn point
            int randomShipIndex = Random.Range(0, enemyShipPrefab.Count);
            Instantiate(enemyShipPrefab[randomShipIndex], spawnPoint.position, transform.rotation, null);
        }
       
        Ship playerShip = FindObjectOfType<PlayerShip>();
        playerShip.currentTurboShotAmmo++;
        
        HUD.Instance.DisplayAmmo(playerShip.currentTurboShotAmmo);
    }

    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips); //this will print to console so we can test

        if (currentNumberOfShips == 1)
        {
            currentWave++;
            //TODO Update HUD with current wave number
            HUD.Instance.DisplayWave(currentWave);

            SpawnWaveOfEnemies();

            int highestWave = PlayerPrefs.GetInt("HighestRound");

            if (currentWave > highestWave)
            {
                PlayerPrefs.GetInt("HighestRound", currentWave);

                //TODO tell HUD to show highest wave
                HUD.Instance.DisplayHighestWave(currentWave);
            }
        }
    }

}
