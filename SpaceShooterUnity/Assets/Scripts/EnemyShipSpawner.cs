using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{

  public static EnemyShipSpawner Instance;

  public List<GameObject> enemyShipPrefabs;
  public Transform pivotPoint;
  public Transform spawnPoint;
  public AudioSource waveSound;

  int currentShipCount;
  int currentWave;
  int highestWave;
  int baseShipCount;


  private void Awake()
  {
    Instance = this;
    currentWave = 1;
  }

  // Start is called before the first frame update
  void Start()
  {
    baseShipCount = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;
    currentShipCount = baseShipCount;
    highestWave = PlayerPrefs.GetInt("waveHighscore");
    HUD.Instance.DisplayHighestWave(highestWave);
    HUD.Instance.UpdateTurbos(PlayerShip.Instance.turboShots);
  }

  // Update is called once per frame
  public void SpawnEnemyWave()
  {
    int enemiesToSpawn = baseShipCount + currentWave;
    for (int i = 0; i < enemiesToSpawn; i++)
    {
      float newZRotation = Random.Range(0f, 360f);
      pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

      int randomShipIndex = Random.Range(0, enemyShipPrefabs.Count);
      Instantiate(enemyShipPrefabs[randomShipIndex], spawnPoint.position, transform.rotation, null);
    }
    HUD.Instance.DisplayWave(currentWave);
    HUD.Instance.DisplayHighestWave(highestWave);
    PlayerShip.Instance.EarnTurbo(1);
    HUD.Instance.UpdateTurbos(PlayerShip.Instance.turboShots);

    waveSound.Play();
  }

  public void CountEnemies()
  {
    currentShipCount = FindObjectsByType<BaddieShip>(FindObjectsSortMode.None).Length;

    Debug.Log("Current Ship Count: " + currentShipCount);

    if (currentShipCount == 1)
    {
      currentWave++;
      SpawnEnemyWave();

      highestWave = PlayerPrefs.GetInt("waveHighscore");

      if (currentWave > highestWave)
      {
        // SUPER HYPER MEGA YAY
        PlayerPrefs.SetInt("waveHighscore", currentWave);
        HUD.Instance.DisplayHighestWave(currentWave);

      }
    }
  }
}
