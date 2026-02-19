using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int currentTurboShotAmmo;
    public int maxTurboShotAmmo;

    public float acceleration;
    public float currentSpeed;
    public float maxSpeed;

    public float fireRate;

    public Rigidbody2D rb;

    public GameObject projectilePrefab;
    public GameObject explosionPrefab;
    public GameObject turboShotPrefab;

    public float projectileVelocity;

    public Transform projectileSpawnPoint;

    ParticleSystem thrustParticles;

    public AudioSource pewPewAudioSource;
    public AudioSource takeDamageAudioSource;

    public bool canPewPew;

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

        float newPitch = Random.Range(0.9f, 1.1f);

        pewPewAudioSource.pitch = newPitch;

        pewPewAudioSource.Play();

        StartCoroutine(CoolDown());
        
        Destroy(newProjectile, 4);
    }
    public void TurboShot()
    {
        Debug.Log("Turbo");

        GameObject newProjectile = Instantiate(turboShotPrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newProjectile.GetComponent<Projectile>().firingShip = gameObject;

        float newPitch = Random.Range(0.9f, 1.1f);
        pewPewAudioSource.pitch = newPitch;
        pewPewAudioSource.Play();

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);

        //currentTurboShotAmmo -- 1;
               
        HUD.Instance.DisplayAmmo(currentTurboShotAmmo);
    }

    private void TurboShotAmmo(int maxTurboShotAmmo)
    {
        //if (currentTurboShotAmmo < 0)
    }


    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
        takeDamageAudioSource.Play();

        if (GetComponent<PlayerShip>())
        {
            //Display Health
            HUD.Instance.UpdateHealthUI(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Explode();
        }
    }

    public void Explode()
    {
        GameObject newExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

        EnemySpawner.Instance.CountEnemyShips();

        if (GetComponent<PlayerShip>())
        {
            GameManager.Instance.GameOver();
        }

        //code can be called here because were alive

        Destroy(gameObject);
        Destroy(newExplosion, 1);

        //code cant be called here cuz we dead rip
    }

    private IEnumerator CoolDown()
    {
        canPewPew = false;
        yield return new WaitForSeconds(fireRate);
        canPewPew = true;
    }
}