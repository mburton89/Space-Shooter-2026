using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int healthToGain;
    public int speedToGain;

    public bool isHealthBoost;
    public bool isSpeedBoost;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we made it this far we collided with something

        if (collision.GetComponent<PlayerShip>())
        {
            //if we made it this far, the thing we collided with was the player ship

            //health
            if (isHealthBoost)
            { 
                collision.GetComponent<PlayerShip>().GiveHealth(healthToGain);
            }

            //speed
            if (isSpeedBoost)
            {
                collision.GetComponent<PlayerShip>().GiveSpeed(speedToGain);
                Invoke("End Speed boost", 10.0f);

                void EndSpeedBoost()
                {
                    Debug.Log("Action completed via invoke at: " + Time.time);
                }
            }

            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
}
