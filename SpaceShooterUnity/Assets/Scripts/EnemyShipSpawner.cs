using UnityEngine;
using System.Collections.Generic; // w eneed this API for LIST functions
public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance;


    public List<GameObject> enemyShipPrefabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    int currentNumberOfShips;
    int currentWave;
    int baseNumberOfShips;

    // "max waves to beat" game

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
        int NumberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        for(int i = 0; i < NumberOfEnemiesToSpawn; i++)
        {
            //step 1 rotate the Pivot (claw machine arm)
            float newZRotation = Random.Range(0f, 2360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            //step 2: spawn/instantiate the enemy at the spawn point
            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
            Instantiate(enemyShipPrefabs[randomShipIndex], spawnPoint.position, transform.rotation, null);

        }

    }

    //public void SpawnTurboShotAmmo()
   // {                                   ???????
    ///    int NumberOfTurboShotAmmo = 
    //}

    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips);  // this will print to console so we can test

        if (currentNumberOfShips == 1)
        {
            currentWave++;
            HUD.Instance.DisplayWave(currentWave);
            SpawnWaveOfEnemies();

            int HighestWave = PlayerPrefs.GetInt("HighestWave");

            if(currentWave > HighestWave)
            {
                //YYAYYYYYYY! WE SET HIGH SCORE
                PlayerPrefs.SetInt("HighestWave", currentWave);

                //TODO Tell HUD to show highest WAVE
                HUD.Instance.DisplayHighestWave(currentWave);

                //flash color whne new highscore
            }
        }

    } 

}
