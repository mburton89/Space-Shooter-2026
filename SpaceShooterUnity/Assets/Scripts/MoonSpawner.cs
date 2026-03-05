using UnityEngine;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi; //For list function

public class MoonSpawner : MonoBehaviour
{
    public static MoonSpawner Instance;

    public List<GameObject> obstaclePrefabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    int currentNumberOfObstacles;
    int baseNumberOfObstacles;
    int currentWave;

    private void Awake()
    {
        Instance = this;
        currentWave = 1;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseNumberOfObstacles = FindObjectsByType<Obstacles>(FindObjectsSortMode.None).Length;
        currentNumberOfObstacles = baseNumberOfObstacles;

        // InvokeRepeating("CountObstacles", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnWaveOfObstacles()
    {
        float newZRotation = Random.Range(0f, 360f);
        pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

        int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Count);
        Instantiate(obstaclePrefabs[randomObstacleIndex], spawnPoint.position, transform.rotation, null);
    }
    
    public void CountObstacles()
    {
        currentNumberOfObstacles = FindObjectsByType<Obstacles>(FindObjectsSortMode.None).Length;

        if (currentNumberOfObstacles == 0)
        {
            SpawnWaveOfObstacles();
        }
    }
}
