using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieShip : Ship
{

  public float turnSpeed;
  Transform target;
  // Start is called before the first frame update
  void Start()
  {
    target = FindObjectOfType<PlayerShip>().transform;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    FollowTarget();
    Thrust(1f, true);
  }

  void FollowTarget()
  {
    Vector2 dirToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);

    transform.up = Vector2.Lerp(transform.up, dirToFace.normalized, turnSpeed);
  }
}
