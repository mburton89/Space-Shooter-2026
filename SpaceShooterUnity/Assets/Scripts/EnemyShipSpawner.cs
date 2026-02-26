using UnityEngine;
using System.Collections.Generic;
using TreeEditor; //API for List functionality

public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance;

    public List<GameObject> enemyShipPrefabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    int currentNumberOfShips;
    int currentWave;
    int baseNumberOfShips;
    //TODO max waves is we want to "beat" the game

    private void Awake()
    {
        Instance = this;
        currentWave = 1;
    }

    void Start()
    {
        baseNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        currentNumberOfShips = baseNumberOfShips;
        HUD.Instance.DisplayHighestWave(PlayerPrefs.GetInt("HighestWave"));
    }

   public void SpawnWaveOfEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        for(int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            //Step 1: rotate pivot poin (claw arm)
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            //step 2: Spawn/Instantiate the enemy in the spawn point 
            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
            Instantiate(enemyShipPrefabs[randomShipIndex], spawnPoint.position, transform.rotation, null);
        }

        PlayerShip playerShip = FindObjectOfType<PlayerShip>();
        playerShip.currentShots++;
        HUD.Instance.DisplayTurboShot(playerShip.currentShots);

    }

    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips); //this will print to console so we can test

        if(currentNumberOfShips == 1)
        {
            currentWave += 1;



            HUD.Instance.DisplayWave(currentWave); //TODO Update HUD with current wave number
            SpawnWaveOfEnemies();

            int highestWaveAchieved = PlayerPrefs.GetInt("HighestWave");

            if(currentWave > highestWaveAchieved)
            {
                //YAAYYYYY, We set a new high score / wave
                PlayerPrefs.SetInt("HighestWave", currentWave);

                //ToDO Tell HUD to show highest wave
                HUD.Instance.DisplayHighestWave(currentWave);
            }
        }
    }
}
