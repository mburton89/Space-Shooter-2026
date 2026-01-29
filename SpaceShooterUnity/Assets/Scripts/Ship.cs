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
  public Transform projectileSpawnPoint;



  // Start is called before the first frame update
  void Start()
  {


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
    GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    newProjectile.GetComponent<Rigidbody2D>().AddForce(projectileSpawnPoint.up * speed);
    newProjectile.GetComponent<Projectile>().owner = gameObject;
    Destroy(newProjectile, 2f);
  }

  public void TakeDamage(int dmgToTake)
  {
    currentHP -= dmgToTake;
    if (currentHP <= 0)
    {
      Explode();
    }
  }

  public void Explode()
  {
    Destroy(gameObject);
  }


}
