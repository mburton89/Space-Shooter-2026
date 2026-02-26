using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public int HealthToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerShip>())
        {
            collision.GetComponent<PlayerShip>().giveHealth(HealthToGive);

            Destroy(gameObject);
        }
    }
}
