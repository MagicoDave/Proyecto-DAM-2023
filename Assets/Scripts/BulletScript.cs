using UnityEngine;

// Manages Bullet logic
public class BulletScript : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactParticle;
    
    // Asigns a targets to fly towards
    public void Seek (Transform target)
    {
        this.target = target;
    }

    // Update is called once per frame
    void Update()
    {

        // Check if target is no longer there and destroys itself if true
        if (target == null) 
        {
            Destroy(gameObject);
            return;
        }

        // Calculates direction towards target and speed
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // Checks for collisions and invokes HitTarget if true
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // If no collision, flies towards target
        transform.Translate (dir.normalized * distanceThisFrame, Space.World);
        // Bullet rotation (for rockets mainly)
        transform.LookAt(target.position);

    }

    // Instantiates hit particle and destoys the bullet
    void HitTarget()
    {
        GameObject particleInstance = (GameObject) Instantiate(impactParticle, transform.position, transform.rotation);
        Destroy(particleInstance, 5f);

        // Check if the attack has a explosion radious and calls corresponding method
        if (explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }
        
        // Finally, destroys the bullet
        Destroy(gameObject);
    }

    // Damages every enemy caught in the explosionRadius
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            // This comprobation is necessary so we don't blow up unrelated game objects.
            // That would be fun for a different type of game, though.
            if (collider.CompareTag("Enemy"))
            {
                //Debug.Log(collider.name + "is inside radius explosion");
                Damage(collider.transform);
            }
        }
    }

    // Damages a enemy
    void Damage (Transform enemy)
    {
        Destroy(enemy.gameObject); //For debug purposes, we will instead destroy the enemy
    }

    // On selection, paints the range of the explosion radius. For debugging and testing purposes.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
