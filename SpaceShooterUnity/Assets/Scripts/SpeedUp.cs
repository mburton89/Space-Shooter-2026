using JetBrains.Annotations;
using UnityEngine;
using UnityEditor;
using System.Collections;

public class SpeedUp : MonoBehaviour
{
    public int speedBoostToGive;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 20f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("PowerUp collsion");
        //If we made it this far, we collided with SOMETHING

        if (collision.GetComponent<PlayerShip>()) 
        {
            //If we made it this far, the thing we collided with is a SHIP. 

            Debug.Log("GivenSpeed");
            collision.GetComponent<PlayerShip>().GiveSpeed(speedBoostToGive);

           Destroy(gameObject);
        }
        
    }

   

}
