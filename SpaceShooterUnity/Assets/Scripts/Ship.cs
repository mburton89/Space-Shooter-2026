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

    public Rigidbody2D rb;

    public GameObject projectilePrefab;

    public GameObject explosionPrefab;

    public float projectileVelocity;

    public Transform projectileSpawnPoint;

    public AudioSource shootAudioSource;

    public bool canFire;

    ParticleSystem thrustParticles;

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

    public void PewPew()
    {
        Debug.Log("Fire Projectile");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newProjectile.GetComponent<Projectile>().firingShip = gameObject;

        float newPitch = Random.Range(0.5f, 2f);
        shootAudioSource.pitch = newPitch;
        shootAudioSource.Play();

        StartCoroutine(Reload());
        Destroy(newProjectile, 5);
    }

    public void TakeDamage(int damageToTake)
    { 
        currentHealth -= damageToTake;

        if(GetComponent<PlayerShip>())  //display 
        {
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
        Destroy(gameObject);
    }

    private IEnumerator Reload()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
