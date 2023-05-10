using System.Data.SqlTypes;
using TowerDefense.Nodes;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

// Script to manage turrets on tiles
public class TurretManager : MonoBehaviour
{
    public static TurretManager instance;

    private TurretBlueprint turretToBuild;

    public GameObject MachineGunTurretPrefab;
    public GameObject RocketLauncherTurretPrefab;

    public GameObject buildEffect;

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

    // This is used to check if there turretToBuild is not null
    public bool CanBuild { get { return turretToBuild != null; } }
    // This is used to check if the player can afford the cost of the turret
    public bool CanAfford { get { return PlayerStats.money >= turretToBuild.cost; } }

    // Builds a turret on the given tile
    public void BuildTurrentOn (TileScript tile)
    {
        // If player has not enough money for the turret, returns
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that turret!");
            return;
        }

        // Substracts cost of the turret
        PlayerStats.money -= turretToBuild.cost;

        // Builds the turret on the specified tile
        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, tile.GetBuildPosition(), Quaternion.identity);
        tile.turret = turret;

        // Plays a cool steam effect when the turret is built, then destroys it after 2 seconds
        GameObject effect = (GameObject) Instantiate(buildEffect, tile.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        Debug.Log(turret.name +  " successfully built! Money left: " + PlayerStats.money);
    }

    // Sets turretToBuild to the desired TurretBlueprint
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
