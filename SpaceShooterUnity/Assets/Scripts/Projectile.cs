using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public int dmg;
  public GameObject owner;
  public bool isPlayerProjectile;
  public CircleCollider2D daIrcle;
  public bool isTurbo;
  public float projHealth;
  public float sizeValue;

  void Update()
  {
    if (isPlayerProjectile)
    {
      //if (!isTurbo)
      //   {
      // daIrcle.radius = 1f;
      //  }
      GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
    }
  }

  void OnTriggerEnter2D(Collider2D collision)
  {
    if (isPlayerProjectile)
    {
      if (collision.GetComponent<BaddieShip>())
      {
        collision.GetComponent<BaddieShip>().TakeDamage(dmg);
        if (isTurbo)
        {
          //Debug.Log(projHealth);
          projHealth = projHealth - 1f;
          if (projHealth <= 0f)
          {
            EnemyShipSpawner.Instance.CountEnemies();
            Destroy(gameObject);
          }
        }
        else
        {
          Destroy(gameObject);
        }
      }
    }
    else
    {
      if (collision.GetComponent<PlayerShip>())
      {
        collision.GetComponent<PlayerShip>().TakeDamage(dmg);
        Destroy(gameObject);
      }
    }


  }
}
