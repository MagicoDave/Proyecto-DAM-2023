using UnityEngine;

// Manages Turret targetting and logic
public class Turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;

    // This atributtes are common for all towers
    [Header("Common attributes")]
    public float range = 15f;

    // These are exclusive for proyectile-based towers
    [Header("Proyectile-based turret attributes (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    // These are used for laser-based towers
    [Header("Laser-based turret attributes")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slowPct = 0.5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    // Other stats
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        // Calls function UpdateTarget() every 0.5f seconds
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Logic to choose closest target
    void UpdateTarget()
    {      
        // Makes an array with every enemy and declares variables for closest target and shortest distance
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // Selects the closest enemy by distance
        foreach (GameObject e in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, e.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = e;
            }
        }

        // If enemy is within range, it picks it as target. Else, target is null
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        } else
        {
            target = null;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        // If no target, return
        if (target == null)
        {
            if (useLaser) // If its a laser tower and has no target, the laser is disabled
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }

        // Rotate the head of the turret
        LockOnTarget();

        if (useLaser) // Case if laser-based turret
        {
            Laser();
        } else // Case if proyectile-based turret
        {
            // Shoots when fireCountdown is equal or less than zero
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            // Counts down for the next shoot
            fireCountdown -= Time.deltaTime;
        }  

    }

    // Used to move the head of the turret to follow its target
    void LockOnTarget()
    {
        // Direction to 'look' to face the target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        // Turret rotation transformation (only rotates the part needed not the entire object)
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    // If the lineRenderer (laser) is disabled, enables it and conects the firepoint with the target position
    void Laser()
    {
        // This makes the laser continuously deal damage to it's target while its locked
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        // This makes the laser apply a slowdown debuff to it's target
        targetEnemy.Slow(slowPct);

        // Enables laser-related visuals and effects
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        // Set the laser position for starting and end points
        lineRenderer.SetPosition(0, firePoint.position); // Start point
        lineRenderer.SetPosition(1, target.position); // End point

        // These lines are used to correctly positionate and rotate the laser impact effect
        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        impactEffect.transform.position = target.position + dir.normalized;

    }


    // Used to make the turret shoot
    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
        BulletScript bullet = bulletGO.GetComponent<BulletScript>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    // Used to visually check Turret range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
