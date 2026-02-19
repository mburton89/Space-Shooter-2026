using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{   // Start is called before the first frame update
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
        Debug.Log("Fire TurboShot");

        GameObject newTurboExplosion = Instantiate(TurboExplosionPrefab, TurboShotSpawnPoint.position, transform.rotation);

        GameObject newTurboShot = Instantiate(TurboShotPrefab, TurboShotSpawnPoint.position, transform.rotation);

        newTurboShot.GetComponent<Rigidbody2D>().AddForce(transform.up * TurboShotVelocity);
        newTurboShot.GetComponent<TurboShot>().firingShip = gameObject;

        float newPitch = Random.Range(0.9f, 1.1f);

        TurboShotSound.pitch = newPitch;

        TurboShotSound.Play();

        StartCoroutine(TurboShotCoolDown());

        Destroy(newTurboShot, 4);
    }

    private IEnumerator TurboShotCoolDown()
    {
        canTurboShoot = false;
        yield return new WaitForSeconds(fireRate);
        canTurboShoot = true;
    }
}
