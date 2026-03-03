using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossShip : Ship
{
    Transform target;

    public bool isShooter;
    


    public void Barrage()
    {


        Debug.Log("Fire Barrage");
        GameObject newProjectile = Instantiate(barrageShotPrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newProjectile.GetComponent<Projectile>().firingShip = gameObject;

        float newPitch = Random.Range(0.9f, 1.1f);

        pewPewAudioSource.pitch = newPitch;

        pewPewAudioSource.Play();

        Destroy(newProjectile, 4);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if we made it this far, we collided with SOMETHING

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
        if (target != null)
        {
            FollowTarget();

            if (isShooter && canPewPew)
            {
                PewPew();
            }
        }

        if (currentHealth <= 25)
        {
            Barrage();
        }

    }

    void FollowTarget()
    {
        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }
}
