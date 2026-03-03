using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCall : MonoBehaviour
{

  public AudioSource projFlyBy;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D collision)
  {

    if (collision.gameObject.GetComponent<Projectile>().isPlayerProjectile == false && PlayerShip.Instance.turboShots < 3)
    {
      float randPitch = Random.Range(0.9f, 1.1f);
      projFlyBy.pitch = randPitch;
      projFlyBy.Play();
      PlayerShip.Instance.EarnTurbo(1);
      HUD.Instance.UpdateTurbos(PlayerShip.Instance.turboShots);
    }
  }
}
