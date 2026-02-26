using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBulb : MonoBehaviour
{
    public int lifeToGive;

    public GameObject friend;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.GetComponent<Ship>() && collision.gameObject == friend)
        {
        

            collision.GetComponent<Ship>().Givelife(lifeToGive);

            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        friend = FindObjectOfType<PlayerShip>().gameObject;
    }
}
