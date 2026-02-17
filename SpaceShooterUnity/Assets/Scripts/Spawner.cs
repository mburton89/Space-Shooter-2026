using UnityEngine;
using System.Collections.Generic; //For list function

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

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
        HUD.Instance.DisplayHighestWave(PlayerPrefs.GetInt("Highest Wave"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWaveOfEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
            Instantiate(enemyShipPrefabs[randomShipIndex], spawnPoint.position, transform.rotation, null);
        }
    }
    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips); //Prints some stuff

        if(currentNumberOfShips == 1)
        {
            currentWave++; //TODO: HUD stuff

            HUD.Instance.DisplayWave(currentWave);
            SpawnWaveOfEnemies();

            int highestWaveAchieved = PlayerPrefs.GetInt("Highest Wave");

            if(currentWave > highestWaveAchieved)
            {
                //Set High Score
                PlayerPrefs.SetInt("Highest Wave", currentWave);
                HUD.Instance.DisplayHighestWave(currentWave);
            }
        }
    }
}
