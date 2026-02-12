using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieShip : Ship
{
    Transform target;

    public bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            // detect collision with Player Ship
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

            if (canShoot && canFire)
            {
                FireProjectile();
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
