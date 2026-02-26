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
    public Transform explosionSpawnPoint;

    public GameObject turboPreFab;
    public Transform turboSpawnPoint;

    ParticleSystem thrustParticles;

    public AudioSource pewPewAudioSource;
    public AudioSource TurboPewAudioSource;

    public int turboPewPew;

    [HideInInspector] public bool canPewPew;

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

        float newPitch = Random.Range(0.9f, 1.5f);

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
            //display health
            HUD.Instance.UpdateHealthUI(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Explode();
        }
    }
    public void GiveHealth(int healthToGive)
    {
        currentHealth += healthToGive;

        if (GetComponent<PlayerShip>())
        {
            //display health
            HUD.Instance.UpdateHealthUI(currentHealth, maxHealth);
        }

    }

    public void Explode()
    {
        GameObject newExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

        EnemyShipSpawner.Instance.CountEnemyShips();

        if (GetComponent <PlayerShip>())
        {
            GameManager.Instance.GameOver();
        }

        Destroy(gameObject);
        Destroy(newExplosion, 4);
        
        //code cant be called here cause we dead!
    }

    public IEnumerator CoolDown()
    {
        canPewPew = false;
        yield return new WaitForSeconds(fireRate);
        canPewPew = true;
    }
}
