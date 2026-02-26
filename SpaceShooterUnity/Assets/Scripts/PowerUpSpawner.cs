using UnityEngine;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour
{

    Transform target;
     public static PowerUpSpawner Instance;

     public List<GameObject> powerUpPrefabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    public AudioSource addHealthAudio;

    int currentNumberOfPowerUps;
    int baseNumberOfPowerUps;

    private void Awake()
    {
        Instance = this;
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseNumberOfPowerUps = 2;
        
    }

    public void SpawnPowerUpWave()
    {
        Debug.Log("Spawn Power Wave");
        if (EnemyShipSpawner.Instance.currentWave > 2)
        {
        int numberOfPowerUpsToSpawn = Random.Range(1, 5);

        for(int i = 0; i < numberOfPowerUpsToSpawn; i++)
        {
            //Step 1: Rotate the Pivot Point (claw machine arm) of the spawner
            float newZRotation = Random.Range(0f, 360f); 
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation); //Rotate pivot point 2 new angle

             //Step 2: Spawn enemy in spawn point
            int randomPowerUpIndexEasy = Random.Range(0, powerUpPrefabs.Count);
            Instantiate(powerUpPrefabs[randomPowerUpIndexEasy], spawnPoint.position, spawnPoint.rotation, null);
        }
        }
    }


}
