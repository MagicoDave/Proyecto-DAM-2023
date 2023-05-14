using UnityEngine;

// Manages the shop ui to buy new turrets
public class ShopScript : MonoBehaviour
{
    public TurretBlueprint machineGunTurret;
    public TurretBlueprint rocketLauncherTurret;
    public TurretBlueprint laserTurret;

    TurretManager turretManager;

    // Start is called before the first frame update
    void Start()
    {
        turretManager = TurretManager.instance;
    }

    // Selects a Machine Gun Turret prefab
    public void SelectMachineGunTower()
    {
        Debug.Log("Machine Gun Tower selected!");
        turretManager.SelectTurretToBuild(machineGunTurret);
    }

    // Selects a Rocket Launcher Turret prefab
    public void SelectRocketLauncherTower()
    {
        Debug.Log("Rocket Launcher Tower selected!");
        turretManager.SelectTurretToBuild(rocketLauncherTurret);
    }

    // Selects a Laser Turret prefab
    public void SelectLaserTower()
    {
        Debug.Log("Laser Tower selected!");
        turretManager.SelectTurretToBuild(laserTurret);
    }
}
