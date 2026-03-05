using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Ship : MonoBehaviour
{

  public int currentHP;
  public int maxHP;

  public float accel;
  public float currentSpeed;
  public float maxSpeed;

  public float fireRate;
  public int invinTime;

  public Rigidbody2D rb;

  public GameObject projectilePrefab;
  public GameObject turboPrefab;
  public GameObject explosionPrefab;
  public Transform projectileSpawnPoint;

  public AudioSource pewPewSound;
  public AudioSource dmgSound;

  public bool canPewPew;

  public bool isPlayerShip;

  public GameObject healthPrefab;
  public GameObject invinPrefab;

  private float pickupChance;

  public float healthPickupRarity;
  public float invinPickupRarity;


  // Start is called before the first frame update
  private void Awake()
  {
    canPewPew = true;
    pickupChance = Random.Range(0f, 1f);

  }

  private void FixedUpdate()
  {
    if (rb.velocity.magnitude > maxSpeed)
    {
      rb.velocity = rb.velocity.normalized * maxSpeed;
    }
    if (invinTime > 0)
    {
      invinTime--;
    }
  }

  public void Thrust(float power, bool vertical)
  {
    if (vertical)
    {
      rb.AddForce(transform.up * accel * power);
    }
    else
    {
      rb.AddForce(transform.right * accel * power);
    }
  }

  public void PewPew(float speed)
  {
    if (!canPewPew) return;
    GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    newProjectile.GetComponent<Rigidbody2D>().AddForce(projectileSpawnPoint.up * speed);
    newProjectile.GetComponent<Projectile>().owner = gameObject;
    newProjectile.GetComponent<Projectile>().isPlayerProjectile = isPlayerShip;

    pewPewSound.Play();

    StartCoroutine(Cooldown());

    Destroy(newProjectile, 4f);
  }

  public void TakeDamage(int dmgToTake)
  {
    if (invinTime <= 0)
    {
      currentHP -= dmgToTake;
      if (isPlayerShip)
      {
        HUD.Instance.UpdateHealthUI(currentHP, maxHP);
        dmgSound.Play();
        HUD.Instance.flashRed();
        invinTime = 10;
      }
    }

    if (currentHP <= 0)
    {
      Explode();
    }
  }

  public void Explode()
  {
    GameObject explosion = Instantiate(explosionPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

    if (!isPlayerShip)
    {
      EnemyShipSpawner.Instance.CountEnemies();
      if (pickupChance < healthPickupRarity)
      {
        Instantiate(healthPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
      }
      else if (pickupChance < healthPickupRarity + invinPickupRarity)
      {
        Instantiate(invinPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
      }
    }
    else
    {
      GameManager.Instance.GameOver();
    }


    Destroy(explosion, 1f);
    Destroy(gameObject);
  }

  private IEnumerator Cooldown()
  {
    canPewPew = false;
    float randMult = Random.Range(0.5f, 1.5f);
    yield return new WaitForSeconds(fireRate * randMult);
    canPewPew = true;
  }

  public void MakeInvin(int time)
  {
    invinTime += time;
    if (invinTime > 300)
    {
      invinTime = 300;
    }
  }


}
