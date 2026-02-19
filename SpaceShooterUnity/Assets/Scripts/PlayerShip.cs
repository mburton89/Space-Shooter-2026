using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{

    public int turboAmmo = 3;
    public GameObject turboProjectilePrefab;
    public AudioSource turboAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PewPew();
        }

        if (Input.GetKeyDown(KeyCode.Space) && turboAmmo > 0 && canPewPew)
        {
            TurboShot();
        }

        if (Input.GetMouseButton(1))
        {
            Thrust();
        }

        FollowMouse();


      

    }

    void FollowMouse()
    {
        //Step 1: Find out where mouse cursor is relative to camera and screen
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        //Step 2: Determine the direction between the ship and the mouse cursor
        Vector2 directionToFace = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        //Step 3: Make the ship actually point toward the mouse cursor
        transform.up = directionToFace;
    }

    void TurboShot()
    {
        GameObject newProjectile = Instantiate(
            turboProjectilePrefab,
            projectileSpawnPoint.position,
            transform.rotation
        );

        newProjectile.GetComponent<Rigidbody2D>()
            .AddForce(transform.up * projectileVelocity);

        newProjectile.GetComponent<Projectile>().firingShip = gameObject;

        turboAudioSource.Play();

        turboAmmo--;

        HUD.Instance.UpdateTurboUI(turboAmmo);

        StartCoroutine(CoolDown());

        Destroy(newProjectile, 4);
    }

    private IEnumerator CoolDown()
    {
        throw new NotImplementedException();
    }
}

