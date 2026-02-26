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

  public Rigidbody2D rb;

  public GameObject projectilePrefab;
  public GameObject turboPrefab;
  public GameObject explosionPrefab;
  public Transform projectileSpawnPoint;

  public AudioSource pewPewSound;
  public AudioSource dmgSound;

  public bool canPewPew;

  public bool isPlayerShip;


  // Start is called before the first frame update
  void Start()
  {
    canPewPew = true;

  }

  // Update is called once per frame
  void Update()
  {
    //Camera.main.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
  }

  private void FixedUpdate()
  {
    if (rb.velocity.magnitude > maxSpeed)
    {
      rb.velocity = rb.velocity.normalized * maxSpeed;
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
    currentHP -= dmgToTake;
    if (isPlayerShip)
    {
      HUD.Instance.UpdateHealthUI(currentHP, maxHP);
      dmgSound.Play();
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


}
