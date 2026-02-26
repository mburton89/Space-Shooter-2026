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
        HUD.Instance.DisplayHighestWave(PlayerPrefs.GetInt("HighestWave"));
    }

    public void SpawnWaveOfEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            //Step 1: Rotate the Pivot Point (claw machine arm pivot) 
            float newZRotation = Random.Range(numberOfEnemiesToSpawn, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            //Step 2: Spawn the enemy in the spawn point
            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
            Instantiate(enemyShipPrefabs[randomShipIndex], spawnPoint.position, transform.rotation, null);
        }

        Ship playerShip = FindObjectOfType<PlayerShip>();
        playerShip.currentCharge++;
        HUD.Instance.DisplayShot(playerShip.currentCharge);
    }

    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Numberof Current Enemy Ships:" + currentNumberOfShips); //this will print to console so we can test

        if(currentNumberOfShips == 1)
        {
            currentWave++;
            HUD.Instance.DisplayWave(currentWave); //TODO Update Hud with current wave number
            SpawnWaveOfEnemies();

            int highestWaveAchieved = PlayerPrefs.GetInt("HighestWave");

            if (currentWave > highestWaveAchieved)
            {
                //YAYYYYY, WE SET A NEW HIGH SCORE / WAVE
                PlayerPrefs.SetInt("HighestWave", currentWave);
                //TODO Tell HUD to show highest wave
                HUD.Instance.DisplayHighestWave(currentWave);
            }
        }
    }
}
