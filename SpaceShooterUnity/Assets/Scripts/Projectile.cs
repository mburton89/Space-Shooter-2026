using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public int dmg;
  public GameObject owner;

  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.GetComponent<Ship>() && collision.gameObject != owner)
    {
      collision.GetComponent<Ship>().TakeDamage(dmg);
      Destroy(gameObject);
    }

  }
}
