using UnityEngine;

// Logic for waypoints, used to guide enemys on its path
public class WaypointsScript : MonoBehaviour
{
    // Array with every waypoint on the level
    public static Transform[] points;

    // Initializes the array with the waypoints of the level
    void Awake()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

}
