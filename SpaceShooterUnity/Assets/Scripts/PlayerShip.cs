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
        
        //input.getkey  ("space") or (KeyCode.Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurboPew();
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
    public void TurboPew()
    {
        Debug.Log("TurboPew: " + turboPewPew);
        if (turboPewPew > 0)
        {
            Debug.Log("Fire Projectile");
            GameObject newProjectile = Instantiate(turboPreFab, turboSpawnPoint.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
            newProjectile.GetComponent<Projectile>().firingShip = gameObject;

            float newPitch = Random.Range(0.9f, 1.5f);

            TurboPewAudioSource.pitch = newPitch;

            TurboPewAudioSource.Play();

            StartCoroutine(CoolDown());

            Destroy(newProjectile, 4);

            turboPewPew--;

            if (GetComponent<PlayerShip>())
            {
                HUD.Instance.DisplayTurboPew(turboPewPew);
            }

            //TODO figure out how to make it go up per wave
            Debug.Log("add turbo pew?");

        }
    }
}

