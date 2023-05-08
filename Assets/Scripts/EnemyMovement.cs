using UnityEngine;

// Class for enemy movement logic
public class EnemyMovement : MonoBehaviour
{

    public float speed = 10f;
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
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WaypointsScript.points[wavepointIndex];
    }
}
