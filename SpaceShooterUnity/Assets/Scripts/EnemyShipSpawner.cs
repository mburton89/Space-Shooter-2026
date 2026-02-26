
using UnityEngine;
using System.Collections.Generic;
using System.Collections.Concurrent; // we need this API for LIST functionality
public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance;
    
    public List<GameObject> enemyShipPrefabs;
    
    public Transform pivotPoint;
    
    public Transform spawnPoint;
    
    int currentNumberOfShips;
    
    int currentWave;

    int currentQuadAmmo;
    
    int baseNumberOfShips;
    
    
    //TODO max waves if we want to "beat" the game
    private void Awake()
    {
        Instance = this;
        currentWave = 1;
        currentQuadAmmo = 3;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        baseNumberOfShips =
        FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        currentNumberOfShips = baseNumberOfShips;
        HUD.Instance.DisplayHighestWave(PlayerPrefs.GetInt("HighestWave"));
    }
    
    public void SpawnWaveOfEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            //Rotate the Pivot Point (claw machine arm pivot)
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0,0,newZRotation);

            // Spawn/Instantiate the enemy at the Spawn Point
            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
            Instantiate(enemyShipPrefabs[randomShipIndex], spawnPoint.position, transform.rotation, null);

        }
        PlayerShip playerShip = FindObjectOfType<PlayerShip>();

        HUD.Instance.DisplayCurrentQuadAmmo(playerShip.currentQuadAmmo);
    }


    public void CountEnemyShips()
    {
        currentNumberOfShips =
        FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        Debug.Log("Number of Current Enemy Ships: " + currentNumberOfShips); //this will print to console so we can test
    if (currentNumberOfShips == 1)
        {
            currentWave++;
            if (FindObjectOfType<PlayerShip>().currentQuadAmmo < 3)
            {
                FindObjectOfType<PlayerShip>().currentQuadAmmo++;
            }
            //TODO Update HUD with current wave number
            HUD.Instance.DisplayWave(currentWave);

            SpawnWaveOfEnemies();

            int highestWaveAchieved = PlayerPrefs.GetInt("HighestWave");

            if(currentWave > highestWaveAchieved) 
            {
                PlayerPrefs.SetInt("HighestWave", currentWave);

                //TODO: tell HUD to show highest wave
                HUD.Instance.DisplayHighestWave(currentWave);
            }
        }
    }

    public void CountCurrentQuadAmmo()
    {
        currentQuadAmmo =
        FindObjectsByType<Ship>(FindObjectsSortMode.None).Length;
        Debug.Log("Quad Laser Ammo: " + currentQuadAmmo);
    }
}
