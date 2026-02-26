using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{

    public int maxQuadAmmo = 3;
    public int currentQuadAmmo;
    public void QuadLaser()
    {
        Debug.Log("Fire Quad");
        GameObject quadLaserProjectile = Instantiate(quadLaserPrefab, quadLaserSpawnPoint.position, transform.rotation);
        quadLaserProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * quadLaserVelocity);
        quadLaserProjectile.GetComponent<Projectile>().firingShip = gameObject;

        quadLaserAudioSource.Play();

        currentQuadAmmo--;
        HUD.Instance.DisplayCurrentQuadAmmo(currentQuadAmmo);

        Destroy(quadLaserProjectile, 20);
    }
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

        if (Input.GetKeyDown(KeyCode.Space) && currentQuadAmmo > 0)   
            {
                Debug.Log("Quad Laser Ammo: " + currentQuadAmmo);
                QuadLaser();
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
