using UnityEngine;

// Script to manage turrets on tiles
public class TurretManager : MonoBehaviour
{
    public static TurretManager instance;

    private GameObject turretToBuild;
    public GameObject standardTurretPrefab;

    // This method makes sure we only have one instance of the TurretManager
    // instead of calling a new one each time we click on a Tile
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one TurretManager in scene!");
            return;
        }

        instance = this;
    }

    // Sets the turret to build to one of the prefabs
    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    // Get method for turretToBuild
    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
