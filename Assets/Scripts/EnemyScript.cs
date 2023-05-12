using UnityEngine;

// Class for enemy movement logic
public class EnemyScript : MonoBehaviour
{
    // Movement speed of the Enemy
    public float speed = 10f;
    // Ammount of damage the Enemy can take before being destroyed
    public int health = 100;
    // Money the Enemy drops when killed
    public int loot = 50;
    // Death effect
    public GameObject deathEffect;
    // The current waypoint the enemy is heading for
    private Transform target;
    // This is used to track witch waypoint comes next
    private int wavepointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Sets the first waypoint as the next goal
        target = WaypointsScript.points[0];
    }

    // Deals damage to the health of the Enemy
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) 
        {
            Die();
        }
    }

    // Destroys the Enemy
    void Die()
    {
        // Death effect
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        // Adds its loot to player's money
        PlayerStats.money += loot;
        // Destroys the enemy
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the enemy towards the waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // When the enemy reaches the waypoint, it moves towards the next one
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    // Checks if the enemy reached the last waypoint and destroys it if that's the case.
    // If not, increases the index and takes as target the next waypoint
    void GetNextWaypoint()
    {
        if (wavepointIndex >= WaypointsScript.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = WaypointsScript.points[wavepointIndex];
    }

    void EndPath ()
    {
        PlayerStats.lives--;
        Destroy (gameObject);
    }
}
