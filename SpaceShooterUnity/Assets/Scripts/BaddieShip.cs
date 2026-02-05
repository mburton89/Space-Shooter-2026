using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieShip : Ship
{

  public float turnSpeed;
  public float projSpeed;
  Transform target;
  public int baddieType; // 0 = rammer, 1 = shooter

  // Start is called before the first frame update
  void Start()
  {
    target = FindObjectOfType<PlayerShip>().transform;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {

    if (collision.gameObject.GetComponent<PlayerShip>())
    {
      collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
      Explode();
    }
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    FollowTarget();
    Thrust(1f, true);
    if (baddieType == 1)
    {
      PewPew(projSpeed);
    }
  }

  void FollowTarget()
  {
    Vector2 dirToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);

    transform.up = Vector2.Lerp(transform.up, dirToFace.normalized, turnSpeed);
  }
}
