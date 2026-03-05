using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCall : MonoBehaviour
{
  private float closeCallAmount = 0f;
  public AudioSource projFlyBy;

  private float invinIndic;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    invinIndic = PlayerShip.Instance.invinTime / 300f;
    GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 1f, invinIndic);


    //if (closeCallAmount > 0f)
    //{
    //  closeCallAmount -= 0.025f;
    //}
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {

    if (collision.gameObject.GetComponent<Projectile>().isPlayerProjectile == false)
    {

      //closeCallAmount = 0.5f;
      float randPitch = Random.Range(0.8f, 1.2f);
      projFlyBy.pitch = randPitch;
      projFlyBy.Play();
      //PlayerShip.Instance.EarnTurbo(1);
      //HUD.Instance.UpdateTurbos(PlayerShip.Instance.turboShots);

    }

  }
}

