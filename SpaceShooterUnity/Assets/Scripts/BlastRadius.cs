using System.Threading;
using UnityEngine;

public class BlastRadius : MonoBehaviour
{
    public Collider2D blastCollider;
    public float growthRate = 0.001f;
    public float maxSize = 1f;
//    public bool startFromZero = true;
//    public bool startGrowingImmediately = true;

    private Vector3 initialScale;
    private Vector3 targetScale;
    private bool isGrowing = false;
    private float currentGrowthProgress = 0f;

    public int damageToGive;

    [HideInInspector] public GameObject firingShip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // store starting scale
        initialScale = transform.localScale;
        // if startFromZero

        transform.localScale = Vector3.zero;
        currentGrowthProgress = 0f;

        targetScale = Vector3.one * maxSize;

        // if startGrowingImmediately
        StartGrowing();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we made it this far, we collided with SOMETHING

        if (collision.GetComponent<Ship>() && collision.gameObject != firingShip)
        {
            //If we made it this far, the thing we collided with is a SHIP. WOOHOO! ANNNNNNDD, its not the ship that fired the projectile

            collision.GetComponent<Ship>().TakeDamage(damageToGive);

            Destroy(gameObject, 1);
        }
    }
    public void StartGrowing()
    {
        isGrowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isGrowing) return;

        //increase progress
        currentGrowthProgress += Time.deltaTime * growthRate;

        //capture current scale
        float t = Mathf.Clamp01(currentGrowthProgress / maxSize);
        Vector3 currentScale = Vector3.Lerp(initialScale, targetScale, t);

        transform.localScale = currentScale;

        //stop growing on target
        if ( t>- 1f)
        {
            transform.localScale = targetScale;
            isGrowing = false;
        }

    }



}
