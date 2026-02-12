using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public int dmg;
  public GameObject owner;
  public bool isPlayerProjectile;

  void Update()
  {
    if (isPlayerProjectile)
    {
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
        Destroy(gameObject);
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
