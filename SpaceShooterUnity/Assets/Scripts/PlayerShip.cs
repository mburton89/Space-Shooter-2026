using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerShip : Ship
{
  public static PlayerShip Instance;
  public int turboShots;

  public bool chargingTurbo;

  public float turboChargeAmount;
  public float turboChargeRate;
  public float turboChargeMax;



  public AudioSource turboSound;
  public AudioSource superTurboSound;
  public AudioSource chargeSound;

  private void Awake()
  {
    Instance = this;
  }
  // Start is called before the first frame update
  void Start()
  {
    HUD.Instance.UpdateTurboUI(turboChargeAmount, turboChargeMax);
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
    if (Input.GetKey(KeyCode.Space))
    {
      if (turboShots > 0)
      {
        if (chargingTurbo)
        {
          if (turboChargeAmount < turboChargeMax)
          {
            turboChargeAmount += turboChargeRate;
            HUD.Instance.UpdateTurboUI(turboChargeAmount, turboChargeMax);
          }
          else
          {
            turboChargeAmount = turboChargeMax;
            HUD.Instance.UpdateTurboUI(turboChargeAmount, turboChargeMax);
          }
        }
        else
        {
          chargeSound.Play();
          chargingTurbo = true;
        }
      }
    }
    else
    {
      if (chargingTurbo)
      {
        TurboShot(4000f, (turboChargeAmount / turboChargeMax) + 1f);
      }
      //(((turboChargeAmount * -1) + turboChargeMax) * 30f) + 1000f << old speed formula
      if (invinTime > 0)
      {
        invinTime--;
      }

    }


    void FollowMouse()
    {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

      Vector2 dirToFace = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

      transform.up = dirToFace;
    }
  }
  public void TurboShot(float speed, float size)
  {
    turboShots--;
    chargingTurbo = false;
    chargeSound.Stop();
    if (turboChargeAmount > 40f)
    {
      superTurboSound.Play();
    }

    turboSound.Play();
    turboChargeAmount = 0;

    HUD.Instance.UpdateTurboUI(turboChargeAmount, turboChargeMax);
    GameObject newProjectile = Instantiate(turboPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    newProjectile.GetComponent<Projectile>().projHealth = (size - 1) * 5f;
    //newProjectile.GetComponent<Projectile>().daIrcle.radius = size / 2;
    newProjectile.GetComponent<Rigidbody2D>().AddForce(projectileSpawnPoint.up * speed);
    newProjectile.GetComponent<Transform>().localScale = new Vector3(size, size, size);



    newProjectile.GetComponent<Projectile>().owner = gameObject;
    newProjectile.GetComponent<Projectile>().isPlayerProjectile = isPlayerShip;


    HUD.Instance.UpdateTurbos(turboShots);

    Destroy(newProjectile, 4f);
  }

  public void EarnTurbo(int count)
  {
    turboShots += count;
  }

  public void Heal(int amount)
  {
    turboShots = 3;
    HUD.Instance.UpdateTurbos(turboShots);
    if (currentHP + amount <= maxHP)
    {
      currentHP += amount;
      HUD.Instance.UpdateHealthUI(currentHP, maxHP);
    }
  }
}
