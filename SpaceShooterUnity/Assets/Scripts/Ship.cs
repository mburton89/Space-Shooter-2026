using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public float acceleration;
    public float maxAcceleration;
    public float currentSpeed;
    public float maxSpeed;

    public float fireRate;
    public float turboFireRate;

    public Rigidbody2D rb;

    public GameObject projectilePrefab;
    public GameObject explosionPrefab;
    public GameObject turboShotPrefab;
    public GameObject turboShotParticlesPrefab;
    
    public float projectileVelocity;

    public Transform projectileSpawnPoint;
    public Transform explosionSpawnPoint;
    public Transform turboShotSpawnPoint;

    public ParticleSystem thrustParticles;
    public ParticleSystem speedThrustParticles;
    public ParticleSystem turboShotParticles;

    public AudioSource pewPewAudioSource;
    public AudioSource takeDamageAudioSource;
    public AudioSource turboShotAudioSource;
     public AudioSource addHealthAudio;
     public AudioSource addBIGHealthAudio;
     public AudioSource firstSpeedAudio;
     public AudioSource endSpeedAudio;

    public bool canPewPew;
    public bool canTurboShot;
    bool spedUp;
    public int currentTurboShots;
    public int maxTurboShots;




    // Start is called before the first frame update
    void Awake()
    {
        
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
        rb.AddForce(transform.up * acceleration * 20 * Time.deltaTime);
        if (spedUp ==false)
        {
        thrustParticles.Emit(1);
        speedThrustParticles.Stop();
        }

        if (spedUp == true)
        {
            Debug.Log("Particle Switch");
        thrustParticles.Stop();
        speedThrustParticles.Emit(1);
        }
        
    }

    public void PewPew()
    {
        Debug.Log("Fire Projectile");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newProjectile.GetComponent<Projectile>().firingShip = gameObject;


        float newPitch = Random.Range(.5f, 1.6f);

        pewPewAudioSource.pitch = newPitch;
        pewPewAudioSource.Play();

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);

    }

    
    public void TurboShot()
    {
        if (GetComponent<PlayerShip>())
        {
         Ship playerShip = FindAnyObjectByType<PlayerShip>();
        if (currentTurboShots >= 1 && canTurboShot)
            {
                Debug.Log("Turbo Shot");
                GameObject newTurboShot = Instantiate(turboShotPrefab, turboShotSpawnPoint.position, transform.rotation);
                GameObject turboShotParticles = Instantiate(turboShotParticlesPrefab, turboShotSpawnPoint.position, transform.rotation);
                newTurboShot.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
                newTurboShot.GetComponent<TurboShot>().firingShip = gameObject;

                float newPitch = Random.Range(.5f, 1.6f);

                turboShotAudioSource.Play();
                turboShotAudioSource.pitch = newPitch;

                Debug.Log("Current Turbo Shots:" + currentTurboShots);
                playerShip.currentTurboShots --;
                
                LimitTurboShots();
                HUD.Instance.UpdateTurboShotUI(currentTurboShots);

                StartCoroutine(TurboCoolDown());

                Destroy(newTurboShot, 4);
                    }
            
        }
    }

    public void LimitTurboShots()
    {
       
        if (currentTurboShots > maxTurboShots)
        {
            currentTurboShots = maxTurboShots;
            HUD.Instance.UpdateTurboShotUI(currentTurboShots);
        }
         
    }
    public void AddTurboShot()
    {
        Debug.Log("Turbo Shot Bonus");
        currentTurboShots++;
        LimitTurboShots();
        HUD.Instance.UpdateTurboShotUI(currentTurboShots);

    }
    
    public void TakeDamage(int damageToTake)
    { 
        currentHealth -= damageToTake;

        if(GetComponent<PlayerShip>())
        {
            //Display Health
            HUD.Instance.UpdateHealthUI(currentHealth, maxHealth); //Establish a relay race/contract that makes it so the HUD doesn't go until needed by the TakeDamage
        }

        float newPitch = Random.Range(.5f, 1.6f);

        takeDamageAudioSource.pitch = newPitch;
        takeDamageAudioSource.Play();

        if (currentHealth <= 0)
        {
            Explode();
        }
    }

   

    public void Explode()
    {
        //TODO: Make cool 'splosion particles
        GameObject newExplosion = Instantiate(explosionPrefab, explosionSpawnPoint.position, transform.rotation);

        EnemyShipSpawner.Instance.CountEnemyShips(); //Tell spawner to check how many ships are left

        if (GetComponent<PlayerShip>())
        {
            GameManager.Instance.GameOver(); //Tell game manager to start the game over process
        }

        Destroy(gameObject);
        Destroy(newExplosion, 4);
    }


    private IEnumerator CoolDown()
    {
        canPewPew = false;
        yield return new WaitForSeconds(fireRate);
        canPewPew = true;

    }

     public IEnumerator TurboCoolDown()
    {
        canTurboShot = false;
        yield return new WaitForSeconds(turboFireRate);
        canTurboShot = true;

    }
     public void GiveHealth(int healthToGive)
    {
       currentHealth += healthToGive;

       if (GetComponent<PlayerShip>())
        {
            HUD.Instance.UpdateHealthUI(currentHealth, maxHealth);
            addHealthAudio.Play();
            addBIGHealthAudio.Play();
        }
    }

    public void GiveSpeed(int speedBoostToGive)
    {
        spedUp = true;
        acceleration += speedBoostToGive;
        StartCoroutine(SpeedDelay());
        
        firstSpeedAudio.Play();

    }

    public void LimitSpeed()
    {
        if (acceleration > maxAcceleration)
        {
            Debug.Log("Speed Limited");
            spedUp = false;
            acceleration = maxAcceleration;
            endSpeedAudio.Play();
        }
    }

     IEnumerator SpeedDelay()
    {
        yield return new WaitForSeconds(5);
        FindAnyObjectByType<PlayerShip>().LimitSpeed();
    }
    
}
