using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieShip : Ship
{
    Transform target;

    public bool isShooter;
    public float shootDelay = 2f; // seconds before the ship can shoot

    private void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
        canPewPew = false; // Disable shooting initially
        StartCoroutine(EnableShootingAfterDelay());
    }

    IEnumerator EnableShootingAfterDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canPewPew = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Explode();
        }
    }

    void Update()
    {
        if (target != null)
        {
            FollowTarget();

            if (isShooter && canPewPew)
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

