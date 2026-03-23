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

    bool waveInProgress = true; // prevents multiple triggers

    private void Awake()
    {
        Instance = this;
        currentWave = 1;
    }

    void Start()
    {
        baseNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
        currentNumberOfShips = baseNumberOfShips;

        HUD.Instance.DisplayWave(currentWave);
        HUD.Instance.DisplayHighestWave(PlayerPrefs.GetInt("HighestWave"));

        InvokeRepeating("CountEnemyShips", 0, 1);
    }

    public void SpawnWaveOfEnemies()
    {
        int numberOfEnemiesToSpawn = baseNumberOfShips + currentWave - 1;

        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

            int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);

            Instantiate(
                enemyShipPrefabs[randomShipIndex],
                spawnPoint.position,
                transform.rotation
            );
        }

        waveInProgress = true; // reset flag for next wave
    }

    public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

        Debug.Log("Enemies: " + currentNumberOfShips);

        // WAVE COMPLETE CHECK
        if (waveInProgress && currentNumberOfShips == 0)
        {
            waveInProgress = false;

            currentWave++;

            HUD.Instance.DisplayWave(currentWave);

            // HEAL PLAYER HERE
            PlayerShip player = FindObjectOfType<PlayerShip>();
            if (player != null)
            {
                player.Heal(1); // THIS IS YOUR FEATURE
            }

            // TURBO BONUS
            if (player != null)
            {
                player.turboAmmo += 1;
                HUD.Instance.UpdateTurboUI(player.turboAmmo);
            }

            // HIGH SCORE CHECK
            int highestWaveAchieved = PlayerPrefs.GetInt("HighestWave");

            if (currentWave > highestWaveAchieved)
            {
                PlayerPrefs.SetInt("HighestWave", currentWave);
                HUD.Instance.DisplayHighestWave(currentWave);
            }

            // SPAWN NEXT WAVE
            SpawnWaveOfEnemies();
        }
    }
}