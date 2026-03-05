using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;

public class PickUp : MonoBehaviour
{
  public int type; // 0 = health, 1 = turboshot, 2 = powerup?
  public int amount;

  public GameObject goodiesPrefab;


  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.GetComponent<PlayerShip>())
    {
      switch (type)
      {
        case 0:
          PlayerShip.Instance.Heal(amount);
          break;
        case 1:
          PlayerShip.Instance.EarnTurbo(amount);
          break;
        case 2:
          PlayerShip.Instance.MakeInvin(amount);
          break;



        default: break;
      }

      GameObject goodie = Instantiate(goodiesPrefab, transform.position, new Quaternion(0f, 0f, 0f, 0f));
      Destroy(goodie, 1f);
      Destroy(gameObject);

    }
  }

}
