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

    public AudioSource fireProjectileAudioSource;
    public AudioSource takeDamageAudioSource;

    [HideInInspector] public bool canFire;

    // Start is called before the first frame update
    void Awake()
    {
        thrustParticles = GetComponentInChildren<ParticleSystem>();
        canFire = true;
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

    public void FireProjectile()
    {
            Debug.Log("Fire Projectile");
            GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
            newProjectile.GetComponent<Projectile>().firingShip = gameObject;

            float newPitch = Random.Range(0.7f, 1.3f);

            fireProjectileAudioSource.pitch = newPitch;

            fireProjectileAudioSource.Play();

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

        float newPitch = Random.Range(0.8f, 1.3f);

        takeDamageAudioSource.pitch = newPitch;

        takeDamageAudioSource.Play();

        if (currentHealth <= 0)
        {
            Explode();
        }


    }

    public void Explode()
    {
        GameObject newExplosion = Instantiate(explosionPrefab, projectileSpawnPoint.position, transform.rotation);

        Destroy(gameObject);
    }

    private IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

}
