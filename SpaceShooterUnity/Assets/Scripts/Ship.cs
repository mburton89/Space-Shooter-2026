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

    public ParticleSystem thrustParticles;

    public AudioSource pewpewAudioSource;
    public AudioSource takeDamageAudioSource;

    public bool canPewpPew;

    // Start is called before the first frame update
    void Awake()
    {
        thrustParticles = GetComponentInChildren<ParticleSystem>();
        canPewpPew = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        { 
            rb.velocity = rb.velocity.normalized * maxSpeed;
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

        float newPitch = Random.Range(1f,1.2f);
        pewpewAudioSource.pitch = newPitch;
        pewpewAudioSource.Play();

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);
    }

    public void TakeDamage(int damageToTake)
    {
        takeDamageAudioSource.Play();
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            Explode();
        }
    }

    public void Explode()
    {

        Debug.Log("Set Explosion");
        GameObject newExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    private IEnumerator CoolDown()
    {
        canPewpPew = false;
        yield return new WaitForSeconds(fireRate);
        canPewpPew = true;
    }
}
