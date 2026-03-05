using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurboShot : Projectile
{
  // hai :3
  private void Awake()
  {
    PlayerShipMovement.Instance.Kickback(projHealth * 1000f);
  }
}
