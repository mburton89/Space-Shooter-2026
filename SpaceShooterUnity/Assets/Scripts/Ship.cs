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

    public AudioSource pewPewAudioSource;

    public bool canPewPew;

    void Awake()
    {
        thrustParticles = GetComponentInChildren<ParticleSystem>();
        canPewPew = true;
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

        GameObject newProjectile = Instantiate(
            projectilePrefab,
            projectileSpawnPoint.position,
            transform.rotation
        );

        newProjectile.GetComponent<Rigidbody2D>()
            .AddForce(transform.up * projectileVelocity);

        newProjectile.GetComponent<Projectile>().firingShip = gameObject;

        float newPitch = Random.Range(0.9f, 1.1f);
        pewPewAudioSource.pitch = newPitch;
        pewPewAudioSource.Play();

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);
    }

    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;

        // Update HUD if player
        if (GetComponent<PlayerShip>())
        {
            HUD.Instance.UpdateHealthUI(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Explode();
        }
    }

    // NEW: Heal function
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);

        if (GetComponent<PlayerShip>())
        {
            HUD.Instance.UpdateHealthUI(currentHealth, maxHealth);
        }

        Debug.Log("+ " + amount + " HP");
    }

    public void Explode()
    {
        Instantiate(
            explosionPrefab,
            projectileSpawnPoint.position,
            transform.rotation
        );

        EnemyShipSpawner.Instance.CountEnemyShips();

        if (GetComponent<PlayerShip>())
        {
            GameManager.Instance.GameOver();
        }

        Destroy(gameObject);
    }

    private IEnumerator CoolDown()
    {
        canPewPew = false;
        yield return new WaitForSeconds(fireRate);
        canPewPew = true;
    }
}