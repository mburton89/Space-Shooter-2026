using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaddieShip : Ship
{
    Transform target;
    //bool or boolean is a true or false statement essentially
    public bool isShoota;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            //if we made it this far, we collided with THE PLAYER SHIP
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Explode();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            FollowTarget();

            if (isShoota && canPewPew)
            {                
                PewPew();
            }
        }

    }

    void FollowTarget()
    {
        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }
}
