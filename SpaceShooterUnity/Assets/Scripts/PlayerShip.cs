using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerShip : Ship
{

    public int maxShots = 3;
    public int currentShots;

    public void turboShot()
    {
        

        Debug.Log("Fire Turbo Shot");
        GameObject newProjectile = Instantiate(turboShotPrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newProjectile.GetComponent<Projectile>().firingShip = gameObject;

        float newPitch = Random.Range(0.9f, 1.1f);

        pewPewAudioSource.pitch = newPitch;

        pewPewAudioSource.Play();

        currentShots--;
        HUD.Instance.DisplayTurboShot(currentShots);

        Destroy(newProjectile, 4);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentShots = maxShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PewPew();
        }

        if (Input.GetMouseButton(1))
        {
            Thrust();
        }


        if (Input.GetKeyDown(KeyCode.Space) && currentShots > 0)

        {
            Debug.Log("current Shots " + currentShots);
            Debug.Log("Max Shots " + maxShots);
            turboShot();
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

    
}
