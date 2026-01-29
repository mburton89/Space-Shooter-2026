using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public float acceleration;
    public float currentSpeed;
    public float maxSpeed;

    public float fireRate;

    public Rigidbody2D rb;

    public GameObject projectilePrefab;

    public GameObject explosionPrefab;

    public float projectileVelocity;

    public Transform projectileSpawnPoint;

    ParticleSystem thrustParticles;

    // Start is called before the first frame update
    void Awake()
    {
        thrustParticles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        { 
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    public void Thrust()
    {
        rb.AddForce(transform.up * acceleration);
        thrustParticles.Emit(1);
    }

    public void PewPew()
    {
        Debug.Log("Fire Projectile");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newProjectile.GetComponent<Projectile>().firingShip = gameObject;
        Destroy(newProjectile, 4);
    }

    public void TakeDamage(int damageToTake)
    { 
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            Explode();
        }
    }

    public void Explode()
    {
        //TODO: Make cool 'splosion particles
        GameObject newExlosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
