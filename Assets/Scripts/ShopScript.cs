using UnityEngine;

// Manages the shop ui to buy new turrets
public class ShopScript : MonoBehaviour
{
    public TurretBlueprint machineGunTurret;
    public TurretBlueprint rocketLauncherTurret;

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
        //TODO: Rocket Launcher is not created yet
        Debug.Log("Rocket Launcher Tower selected!");
        turretManager.SelectTurretToBuild(rocketLauncherTurret);
    }

    //public void BuySniperTower()
    //{
    //    Debug.Log("Sniper Tower purchased!");
    //}

    //public void BuyPylonTower()
    //{
    //    Debug.Log("Pylon Tower purchased!");
    //}

    //public void BuyEMPTower()
    //{
    //    Debug.Log("EMP Tower purchased!");
    //}

    //public void BuySuperTower()
    //{
    //    Debug.Log("Super Tower purchased!");
    //}
}
