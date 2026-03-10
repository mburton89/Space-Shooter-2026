using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HealPowerUp : MonoBehaviour
{
    Transform target;
    private Rigidbody2D rb;
    public float acceleration;

    public void Thrust()
    {
        rb.AddForce(transform.up * acceleration);
    }

    public int healthRestore = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            collision.gameObject.GetComponent<PlayerShip>().HealDamage(1);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (target != null)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }
}
