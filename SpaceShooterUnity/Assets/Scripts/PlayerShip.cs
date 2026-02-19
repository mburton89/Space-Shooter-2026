using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    
    public GameObject glitterBombPrefab;

    public int maxGlitterBombs = 3;
    public int currentGlitterBombs;

    // Start is called before the first frame update
    void Start()
    {
        currentGlitterBombs = maxGlitterBombs;
        HUD.Instance.UpdateGlitterBombInventory(currentGlitterBombs);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }

        if (Input.GetMouseButton(1))
        {
            Thrust();
        }

        FollowMouse(); 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentGlitterBombs >=1)
            {
                ShootGlitterBomb(); 
            }
            else
            {
                Debug.Log("Out of bombs!");
            }
        }
    }

    public void ShootGlitterBomb()
    {

        GameObject newBomb = Instantiate(glitterBombPrefab, projectileSpawnPoint.position, transform.rotation);
        newBomb.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileVelocity);
        newBomb.GetComponent<GlitterBomb>().firingShip = gameObject;

        currentGlitterBombs--;

        Debug.Log("Current bombs: " + currentGlitterBombs);

        HUD.Instance.UpdateGlitterBombInventory(currentGlitterBombs);

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

    public void ReplenishBombs()
    {
        Debug.Log("Replenish Bombs!");
        
        currentGlitterBombs++;
        HUD.Instance.UpdateGlitterBombInventory(currentGlitterBombs);
    }
}
