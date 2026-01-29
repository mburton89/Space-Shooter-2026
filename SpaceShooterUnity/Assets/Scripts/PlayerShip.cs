using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  private void FixedUpdate()
  {
    FollowMouse();
    Camera.main.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

    if (Input.GetMouseButton(0))
    {
      PewPew(1500f);
    }

    if (Input.GetKey(KeyCode.W))
    {
      Thrust(1f, true);
    }
    if (Input.GetKey(KeyCode.S))
    {
      Thrust(-1f, true);
    }
    if (Input.GetKey(KeyCode.D))
    {
      Thrust(1f, false);
    }
    if (Input.GetKey(KeyCode.A))
    {
      Thrust(-1f, false);
    }
  }


  void FollowMouse()
  {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

    Vector2 dirToFace = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

    transform.up = dirToFace;
  }
}
