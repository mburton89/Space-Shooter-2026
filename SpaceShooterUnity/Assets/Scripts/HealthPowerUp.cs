using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public int lifeToGive;
    public int maxLifeToGive;

    public GameObject health;
    public AudioClip heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Ship>() && collision.gameObject == health && health.GetComponent<PlayerShip>().currentHealth < health.GetComponent<PlayerShip>().maxHealth)
        {
            AudioSource.PlayClipAtPoint(heal, Camera.main.transform.position, 1f);
            collision.GetComponent<Ship>().GiveLife(lifeToGive);

            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        health = FindObjectOfType<PlayerShip>().gameObject;
    }
}