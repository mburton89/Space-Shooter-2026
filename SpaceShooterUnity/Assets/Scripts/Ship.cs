using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int currentNumberOfTurboShots;
    public int turboShotAmmo;

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

    public GameObject TurboShotPrefab;
    public GameObject TurboExplosionPrefab;
    public float TurboShotVelocity;
    public Transform TurboShotSpawnPoint;
    public AudioSource TurboShotSound;

    public bool canTurboShoot;

    // Start is called before the first frame update
    void Awake()
    {
        thrustParticles = GetComponentInChildren<ParticleSystem>();
        canPewPew = true;
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

        float newPitch = Random.Range(0.9f, 1.1f);

        pewPewAudioSource.pitch = newPitch;

        pewPewAudioSource.Play();

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);
    }

    public void TakeDamage(int damageToTake)
    { 
        currentHealth -= damageToTake;

        if (GetComponent<PlayerShip>())
        {
            HUD.Instance.UpdateHealthUI(currentHealth, maxHealth);
        }

        EnemyShipSpawner.Instance.CountEnemyShips();

        if (currentHealth <= 0)
        {
            if (GetComponent<PlayerShip>())
            {
                GameManager.Instance.GameOver();
            }

            Explode();
        }
    }

    public void Explode()
    {
        //TODO: Make cool 'splosion particles
        GameObject newExplosion = Instantiate(explosionPrefab, projectileSpawnPoint.position, transform.rotation);

        Destroy(gameObject);
    }

    private IEnumerator CoolDown()
    {
        canPewPew = false;
        yield return new WaitForSeconds(fireRate);
        canPewPew = true;
    }

    internal void Givelife(int lifeToGive)
    {
        currentHealth += lifeToGive;
        HUD.Instance.UpdateHealthUI(currentHealth, maxHealth);
    }
}
