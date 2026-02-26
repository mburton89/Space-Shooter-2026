using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime; // we need this API for LIST functionality

public class EnemyShipSpawner : MonoBehaviour

{
    public static EnemyShipSpawner Instance;

    public List<GameObject> enemyShipPrefabs;
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
            //Rotate pivot point (claw machine arm pivot)
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            if (currentWave < 3)
            {
                //Soawn/Instantiate the enemy in the spawn point
                int randomShipIndexEasy = Random.Range(0, 2);
                Instantiate(enemyShipPrefabs[randomShipIndexEasy], spawnPoint.position, transform.rotation, null);
            }

            else if (currentWave < 6)
            {
                int randomShipIndexMedium = Random.Range(0, 3);
                Instantiate(enemyShipPrefabs[randomShipIndexMedium], spawnPoint.position, transform.rotation, null);
            }

            else if (currentWave < 9)
            {
                int randomShipIndexHard = Random.Range(0, 5);
                Instantiate(enemyShipPrefabs[randomShipIndexHard], spawnPoint.position, transform.rotation, null);
            }

            else
            {
                int randomShipIndexExtreme = Random.Range(2, 5);
                Instantiate(enemyShipPrefabs[randomShipIndexExtreme], spawnPoint.position, transform.rotation, null);
            }

        }

        Ship playerShip = FindObjectOfType<PlayerShip>();
        playerShip.turboShots++;
    }

    public void CountEnemyShips()
    {

        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships" + currentNumberOfShips); // prints to console for testing

        if (currentNumberOfShips == 1)
        {
            currentWave++;
            //TODO Update HUD with current wave number
            HUD.Instance.DisplayWave(currentWave);

            SpawnWaveOfEnemies();
            PowerUps.Instance.SpawnHealthUps(currentWave);

            int highestWaveAchieved = PlayerPrefs.GetInt("HighestWave");

            if(currentWave > highestWaveAchieved)
            {
                // YAYYYYYYY NEW HIGHSCOREEE
                PlayerPrefs.SetInt("HighestWave", currentWave);

                //TODO Tell HUD to show highest wave
                HUD.Instance.DisplayHighestWave(currentWave);
            }
        }

    }

}
