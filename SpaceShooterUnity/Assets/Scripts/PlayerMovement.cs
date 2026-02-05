using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : Ship
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
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
}
