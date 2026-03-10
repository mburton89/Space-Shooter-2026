using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Rendering.PostProcessing;
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
    }

    void Start()
    {

    }

    public void SpawnHealthUps(int wave)
    {
        int baseNumberOfPowerUps = wave / 5;
        int numberOfUpsToSpawn = baseNumberOfPowerUps + 2;

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
