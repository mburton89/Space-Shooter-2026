using UnityEngine;
using System.Collections.Generic; //Need this API for LIST functions

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
            int randomShipIndexEasy = Random.Range(0, 1);
            int randomShipIndexMedium = Random.Range(2, 3);
            int randomShipIndexHard = Random.Range(2, 4);

            if (currentWave <= 5)
            {
                Instantiate(enemyShipPrefabs[randomShipIndexEasy], spawnPoint.position, spawnPoint.rotation, null);
            }

            if (currentWave >= 10)
            {
                 Instantiate(enemyShipPrefabs[randomShipIndexMedium], spawnPoint.position, spawnPoint.rotation, null);
            }

            if (currentWave >= 15)
            {
                Instantiate(enemyShipPrefabs[randomShipIndexHard], spawnPoint.position, spawnPoint.rotation, null);
            }
        } 
    }

    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips); //this will print to console so we can test

        if(currentNumberOfShips == 1)
        {
            NewWave();
        }
    }

    public void NewWave()
    {
        currentWave++;
        
            SpawnWaveOfEnemies();
            PowerUpSpawner.Instance.SpawnPowerUpWave();
            
            //To Do: Update HUD with current wave #
            HUD.Instance.DisplayWave(currentWave);


            //FindObjectOfType<Ship>().AddTurboShot();
            Debug.Log("Turbo SHot Wave Bonus");
            Ship playerShip = FindObjectOfType<Ship>();
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
