using UnityEngine;

// Class for enemy stats
public class Enemy : MonoBehaviour
{
    // Starting value for movement speed
    public float baseSpeed = 10f;
    // Current value for movement speed
    public float currentSpeed;
    // Ammount of damage the Enemy can take before being destroyed
    public float health = 100;
    // Money the Enemy drops when killed
    public int loot = 50;
    // Death effect
    public GameObject deathEffect;
    // Used to prevent errors registering death
    public bool isDead = false;

    // Initializes values
    void Start()
    {
        currentSpeed = baseSpeed;
    }

    // Deals damage to the health of the Enemy
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0) // If health is equal or less than zero, Enemy dies
        {
            if (isDead)
            {
                return;
            }
            isDead = true;
            Die();
        }
    }

    // Slows down Enemy speed by the percentage value of the float parameter
    public void Slow(float slowPct)
    {
        currentSpeed = baseSpeed * (1f - slowPct);
    }

    // Destroys the Enemy
    void Die()
    {
        // Death effect
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        // Adds its loot to player's money
        PlayerStats.money += loot;
        // Decreases the EnemiesAlive variable for wave logic stuff
        WaveSpawner.EnemiesAlive--;
        // Destroys the enemy
        Destroy(gameObject);
    }

}
