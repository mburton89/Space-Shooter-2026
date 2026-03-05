using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShieldPowerup : MonoBehaviour
{
    public Transform pivotPoint;
    public Transform spawnPoint;
    public List<GameObject> powerupPrefabs;

    public int healthToGive;
    public int currentWave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerShip>())
        {
            collision.GetComponent<PlayerShip>().currentHealth += healthToGive;
            HUD.Instance.UpdateHealthUI(collision.GetComponent<PlayerShip>().currentHealth, collision.GetComponent<PlayerShip>().maxHealth);
            Destroy(gameObject);
        }
    }
    public void SpawnPowerUp()
    {
        int numberOfPowerUps = currentWave - 1;

        for (int i = 0; i < currentWave; i++)
        {
            //Rotate the claw machine arm
            float newZRotation = Random.Range(0f, 360f);
            pivotPoint.eulerAngles = new Vector3(0, 0, newZRotation);
            //Spawn Instantiate the enemy at the Spawn Point
            int randomShipIndex = Random.Range(0, powerupPrefabs.Count);
            Instantiate(powerupPrefabs[randomShipIndex], spawnPoint.position, transform.rotation, null);
        }
        FindObjectOfType<PlayerShip>().turboShotsLeft++;
        HUD.Instance.DisplayTurbo(FindObjectOfType<PlayerShip>().turboShotsLeft);

    }
}
