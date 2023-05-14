using UnityEngine;

// Class for managing enemy movement
[RequireComponent (typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Enemy enemy;

    // The current waypoint the enemy is heading for
    private Transform target;
    // This is used to track witch waypoint comes next
    private int wavepointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();

        // Sets the first waypoint as the next goal
        target = WaypointsScript.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the enemy towards the waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.currentSpeed * Time.deltaTime, Space.World);

        // When the enemy reaches the waypoint, it moves towards the next one
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.currentSpeed = enemy.baseSpeed;
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

    void EndPath()
    {
        WaveSpawner.EnemiesAlive--;
        PlayerStats.lives--;
        Destroy(gameObject);
    }

}
