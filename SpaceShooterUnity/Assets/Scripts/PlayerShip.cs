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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurboShot();
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


    public void TurboShot()
    {
        
        if (currentTurboShots >= 1 && canTurboShot)
            {
        Debug.Log("Turbo Shot");
        GameObject newTurboShot = Instantiate(turboShotPrefab, turboShotSpawnPoint.position, transform.rotation);
        GameObject turboShotParticles = Instantiate(turboShotParticlesPrefab, turboShotSpawnPoint.position, transform.rotation);
        newTurboShot.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newTurboShot.GetComponent<TurboShot>().firingShip = gameObject;

        float newPitch = Random.Range(.5f, 1.6f);

        turboShotAudioSource.Play();
        turboShotAudioSource.pitch = newPitch;

        Debug.Log("Current Turbo Shots:" + currentTurboShots);
        currentTurboShots --;
        
        LimitTurboShots();
        HUD.Instance.UpdateTurboShotUI(currentTurboShots);

         StartCoroutine(TurboCoolDown());

         Destroy(newTurboShot, 4);
            
        }
    }

    
    public void LimitTurboShots()
    {
        if (currentTurboShots > maxTurboShots)
        {
            currentTurboShots = maxTurboShots;
            HUD.Instance.UpdateTurboShotUI(currentTurboShots);
        }
         
    }
   

}
