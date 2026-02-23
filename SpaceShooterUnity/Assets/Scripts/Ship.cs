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

    public GameObject turboShotPrefab;

    public GameObject explosionPrefab;

    public float projectileVelocity;

    public Transform projectileSpawnPoint;

    ParticleSystem thrustParticles;
    ParticleSystem turboShotParticles;

    public AudioSource pewPewAudioSource;

    public bool canPewPew = true;
    public bool canTurboShot;

    void Start()
    {
        currentTurboShotAmmo = maxTurboShotAmmo;
    }

    public int maxAmmo { get; private set; }
    public bool isDisabled { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        thrustParticles = GetComponentInChildren<ParticleSystem>();
        turboShotParticles = GetComponentInChildren<ParticleSystem>();
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

        float newPitch = Random.Range(0.5f, 1.2f);

        pewPewAudioSource.pitch = newPitch;

        pewPewAudioSource.Play();

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);
    }
    public void TurboShot () //int TurboShot    int currentTurboShotAmmo, int maxTurboShotAmmo
    {
        Debug.Log("Fire Projectile");
        GameObject newProjectile = Instantiate(turboShotPrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newProjectile.GetComponent<Projectile>().firingShip = gameObject;

        float newPitch = Random.Range(0.5f, 1.2f);

        pewPewAudioSource.pitch = newPitch;

        pewPewAudioSource.Play();//change audio!!!! call it

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);

        //currentTurboShotAmmo --1 

        currentTurboShotAmmo = 3;
        maxTurboShotAmmo = 3;



        //float ammoAmount = (float)currentturboShotAmmo / (float)maxTurboShotAmmo;

        HUD.Instance.DisplayAmmo(currentTurboShotAmmo);

        //if (currentturboShotAmmo < 0) ;

        //currentturboShotAmmo -= TurboShot;

        if (currentTurboShotAmmo > 0)
        {
            currentTurboShotAmmo --;
            Debug.Log("Ammo Left: " + currentTurboShotAmmo);
        }
        else
        {
            isDisabled = false;
            Debug.Log("Out of Turbo Shots!");

        }

    }

    public void ReplenishTurboShot()
    {
        currentTurboShotAmmo++;
        Debug.Log("TurboShot Ammo Replenished!");

    }

    

    //need to still play sound when take damage bc u r bad at code

    public void TakeDamage(int damageToTake)
    { 
        currentHealth -= damageToTake;

        if(GetComponent<PlayerShip>())
        {
            //display health

            HUD.Instance.UpdateHealthUI(currentHealth, maxHealth);


        }

        if (currentHealth <= 0)
        {
            Explode();

        }
    }


    public void Explode()
    {
        //TODO: Make cool 'splosion particles
        GameObject newExlosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

        EnemyShipSpawner.Instance.CountEnemyShips();

        if(GetComponent<PlayerShip>())
        {
            GameManager.Instance.GameOver();
        }

        //code can be called here bcuz we're ALIVE

        Destroy(gameObject);
        Destroy(newExlosion, 1);
        
        //code cant be called here cuz we DEADDDDDDDDDDDDDD loser
    }

    private IEnumerator CoolDown()
    {
        canPewPew = false;
        yield return new WaitForSeconds(fireRate);
        canPewPew = true;
    }
    // things i want to code on my own: health packs, ally ship spawner, make lazer!!!, 
    //side quest
}
