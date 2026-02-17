using UnityEngine;
using System.Collections.Generic; //we need this API for LIST functionality

public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance;

    public List<GameObject> enemyShipPreFabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    int currentNumberOfShips;
    int currentWave;
    int baseNumberOfShips;


    //TODO max waves if beat game

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
            //step 1 rotate Pivot Point aka claw machine arm
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            //step 2 spawn the enemy in the Spawn Point
            int randomShipIndex = Random.Range(0, enemyShipPreFabs.Count);
            Instantiate(enemyShipPreFabs[randomShipIndex], spawnPoint.position, transform.rotation, null);
        }
    }

    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips); //this will print to console so we can test

        if (currentNumberOfShips == 1)
        {
            currentWave++;
            HUD.Instance.DisplayWave(currentWave); //TODO update HUD with current wave number

            SpawnWaveOfEnemies();

            int highestWaveAchieved = PlayerPrefs.GetInt("HighestWave");

            if (currentWave > highestWaveAchieved)
            {
                //YAAAAYYYYYYYY, WE SET A NEW HIGH SCORE / WAVE
                PlayerPrefs.SetInt("HighestWave", currentWave);

                //TODO Tell HUD to show highest wave
                HUD.Instance.DisplayHighestWave(currentWave);
            }
        }
    }
}
