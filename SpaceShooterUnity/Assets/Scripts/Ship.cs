using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public float acceleration;
    public float currentSpeed;
    public float maxSpeed;

    public float fireRate;
    public float currentCharge;

    public Rigidbody2D rb;

    public GameObject projectilePrefab;
    public GameObject explosionPrefab;
    public GameObject chargePrefab;

    public float projectileVelocity;

    public Transform projectileSpawnPoint;

    ParticleSystem thrustParticles;

    public AudioSource pewPewAudioSource;

    public AudioSource hurtAudioSource;

    public bool canPewPew;
    public bool canCharge;

    // Start is called before the first frame update
    void Awake()
    {
        thrustParticles = GetComponentInChildren<ParticleSystem>();

        StartCoroutine(CoolDown());
        canPewPew = true;
        currentCharge = 3;

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

        float ranPitch = Random.Range(1f, 1.1f);

        pewPewAudioSource.pitch = ranPitch;

        pewPewAudioSource.Play();

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);
    }

    public void ChargeShot()
    {

        if (currentCharge <= 0)
        {
            return;
        }

        Debug.Log("Fire big shot");
        GameObject newProjectile = Instantiate(chargePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newProjectile.GetComponent<Projectile>().firingShip = gameObject;

        float ranPitch = Random.Range(2f, 2f);

        currentCharge--;

        if (GetComponent<PlayerShip>())
        {
            //Display current Health
            HUD.Instance.DisplayShotUI(currentCharge);
        }

        // Subtract until 0, based on upmost If statement

        pewPewAudioSource.pitch = ranPitch;

        pewPewAudioSource.Play();

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);
    }

    public void TakeDamage(int damageToTake)
    {

        float ranPitch = Random.Range(1f, 1.1f);

        hurtAudioSource.pitch = ranPitch;

        hurtAudioSource.Play();

        currentHealth -= damageToTake;

        if (GetComponent<PlayerShip>())
        {
            //Display current Health
            HUD.Instance.updateHealthUI(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Explode();
        }
    }

    public void Explode()
    {
        
        // Controls enemy ship elimination, explosion particles, and player-specific GAME OVER methods

        GameObject newExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

        EnemyShipSpawner.Instance.countEnemyShips();

        if (GetComponent<PlayerShip>())
        {
            GameManager.Instance.GameOver();
        }

        // Start of line, playership is active

        Destroy(gameObject);
        Destroy(newExplosion, 1);

        // End of line, playership has been eliminated
    }

    private IEnumerator CoolDown()
    {
        canPewPew = false;
        yield return new WaitForSeconds(fireRate);
        canPewPew = true;
    }

}
