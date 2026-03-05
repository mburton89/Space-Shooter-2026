using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBulb : MonoBehaviour
{
    public int lifeToGive;
    public int maxLifeToGive;

    public GameObject friend;
    public AudioClip heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.GetComponent<Ship>() && collision.gameObject == friend && friend.GetComponent<PlayerShip>().currentHealth < friend.GetComponent<PlayerShip>().maxHealth)
        {


            AudioSource.PlayClipAtPoint(heal, Camera.main.transform.position, 1f);
            collision.GetComponent<Ship>().Givelife(lifeToGive);

            Destroy(gameObject);

        }

    }

    private void Awake()
    {
        friend = FindObjectOfType<PlayerShip>().gameObject;
    }
}
