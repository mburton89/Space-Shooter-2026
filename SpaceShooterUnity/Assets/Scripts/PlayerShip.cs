using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerShip : Ship
{
  public static PlayerShip Instance;
  public int turboShots;

  public bool canTurbo;
  public AudioSource turboSound;

  private void Awake()
  {
    Instance = this;
  }
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
    if (Input.GetKey(KeyCode.Space))
    {
      if (turboShots > 0 && canTurbo)
      {
        turboShots--;
        canTurbo = false;
        TurboShot(2500f);
        HUD.Instance.UpdateTurbos(turboShots);
      }
    }
    else
    {
      canTurbo = true;
    }


    void FollowMouse()
    {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

      Vector2 dirToFace = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

      transform.up = dirToFace;
    }
  }
  public void TurboShot(float speed)
  {
    GameObject newProjectile = Instantiate(turboPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    newProjectile.GetComponent<Rigidbody2D>().AddForce(projectileSpawnPoint.up * speed);
    newProjectile.GetComponent<Projectile>().owner = gameObject;
    newProjectile.GetComponent<Projectile>().isPlayerProjectile = isPlayerShip;

    turboSound.Play();


    Destroy(newProjectile, 4f);
  }

  public void EarnTurbo(int count)
  {
    turboShots += count;
  }
}
