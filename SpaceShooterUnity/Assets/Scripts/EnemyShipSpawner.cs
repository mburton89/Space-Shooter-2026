using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime; //Need this API for LIST functions
using System.Runtime.InteropServices;

public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance; //Make this a singleton to access from other scripts

    //things to manipulate about spawning
    public List<GameObject> enemyShipPrefabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    public AudioSource newHighScoreAudio;

    //data to consider
    int currentNumberOfShips;
    public int currentWave;
    int baseNumberOfShips;


    //TO DO = Make a max amount of waves if we wanna "beat" the game

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

         InvokeRepeating("CountEnemyShips", 0, 1); //JUST ADDED 3/3/26
    }
         public void CountEnemyShips()
       {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips); //this will print to console so we can test

        if(currentNumberOfShips == 0)
        {
            NewWave();
        }
       }
    public void SpawnWaveOfEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        for(int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            //Step 1: Rotate the Pivot Point (claw machine arm) of the spawner
            float newZRotation = Random.Range(0f, 360f); 
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation); //Rotate pivot point 2 new angle

            //Step 2: Spawn enemy in spawn point
            int randomShipIndexEasy = Random.Range(0, 2);
            int randomShipIndexMedium = Random.Range(0, 4);
            int randomShipIndexHard = Random.Range(0, 5);

            if (currentWave <= 11)
            {
                Instantiate(enemyShipPrefabs[randomShipIndexEasy], spawnPoint.position, spawnPoint.rotation, null);
            }

            if (currentWave >= 12)
            {
                 Instantiate(enemyShipPrefabs[randomShipIndexMedium], spawnPoint.position, spawnPoint.rotation, null);
            }

            if (currentWave >= 13)
            {
                Instantiate(enemyShipPrefabs[randomShipIndexHard], spawnPoint.position, spawnPoint.rotation, null);
            }
        } 
    }


    public void NewWave()
    {
        currentWave++;
        
            SpawnWaveOfEnemies();
            PowerUpSpawner.Instance.SpawnPowerUpWave();
            
            //To Do: Update HUD with current wave #
            HUD.Instance.DisplayWave(currentWave);


           // FindAnyObjectByType<PlayerShip>().AddTurboShot();
            Debug.Log("Turbo Shot Wave Bonus");
            Ship playerShip = FindAnyObjectByType<Ship>();
            playerShip.currentTurboShots++;
            HUD.Instance.UpdateTurboShotUI(playerShip.currentTurboShots);
            playerShip.LimitTurboShots();
            

            int highestWaveAchieved = PlayerPrefs.GetInt("HighestWave");

            if(currentWave > highestWaveAchieved)
            {
                //YAY, WE SET NEW SCORE / WAVE!
                PlayerPrefs.SetInt("HighestWave", currentWave);

                //TO DO: Tell HUD to show highest wave
                HUD.Instance.DisplayHighestWave(currentWave);
                  newHighScoreAudio.Play(); //Play audio for new score
                
            }
    }

}
