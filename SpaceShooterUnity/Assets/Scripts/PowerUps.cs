using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
public class PowerUps : MonoBehaviour
{

    public static PowerUps Instance;

    public List<GameObject> powerupPrefabs;
    public Transform pivotPoint;
    public Transform spawnPoint;

    int baseNumberOfPowerUps;

    private void Awake()
    {
        Instance = this;
        baseNumberOfPowerUps = 2;
    }

    void Start()
    {

    }

    public void SpawnHealthUps(int wave)
    {
        int numberOfUpsToSpawn = baseNumberOfPowerUps + wave;

        if (wave > 2)
        {
            for (int i = 0; i < numberOfUpsToSpawn; i++)
            {
                float newZRotation = Random.Range(0f, 360f);
                pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);

                int randomPowerUpIndex = Random.Range(0, powerupPrefabs.Count);
                Instantiate(powerupPrefabs[randomPowerUpIndex], spawnPoint.position, transform.rotation, null);
            }
        }
    }
}
