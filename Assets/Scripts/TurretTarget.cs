using UnityEngine;

// Manages Turret targetting and logic
public class TurretTarget : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
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
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // If enemy is within range, it picks it as target. Else, target is null
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
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
            return;
        }

        // Direction to 'look' to face the target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        
        // Turret rotation transformation (only rotates the part needed not the entire object)
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // Shoots when fireCountdown is equal or less than zero
        if (fireCountdown <= 0f) 
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        // Counts down for the next shoot
        fireCountdown -= Time.deltaTime;

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
