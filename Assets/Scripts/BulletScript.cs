using UnityEngine;

// Manages Bullet logic
public class BulletScript : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
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
    }

    // Instantiates hit particle and destoys the bullet
    void HitTarget()
    {
        Debug.Log(target.name + " got hit by a bullet"); // Debug

        GameObject particleInstance = (GameObject) Instantiate(impactParticle, transform.position, transform.rotation);
        Destroy(particleInstance, 2f);
        Destroy(gameObject);
    }

}
