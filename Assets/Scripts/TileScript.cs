using UnityEngine;
using UnityEngine.EventSystems;

// Script to manage Tile logic
public class TileScript : MonoBehaviour
{
    TurretManager turretManager;

    private Renderer rend;
    private Color startColor;
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Vector3 positionOffset = new Vector3(0, 0.5f, 0);

    // This is used for level design, so we can start a level with certain turrets
    // already built in the level
    [Header("Prebuilt turret?")]
    public GameObject turret;

    // Gets default color and renderer on start
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        turretManager = TurretManager.instance;
    }

    // This returns the position where turrets should be built on the tile
    public Vector3 GetBuildPosition()
    {
         return transform.position + positionOffset;
    }

    // Change color on mouse enter for user readability
    private void OnMouseEnter()
    {
        //Checks that the mouse is not over another gameobject and returns if it is
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Checks if the turret manager has something to build and returns if it doesnt
        if (!turretManager.CanBuild)
        {
            return;
        }

        // Checks if the player can afford or not the cost of the turret and changes
        // the color of the tile accordingly
        if (turretManager.CanAfford)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }

    // Back to default color on mouse exit for user readability
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    // Builds a tower on the clicked Tile
    private void OnMouseDown()
    {
        //Checks that the mouse is not over another gameobject and returns if it is
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Checks if the turret manager has something to build and returns if it doesnt
        if (!turretManager.CanBuild)
        {
            return;
        }

        // Checks if there is a turret in this tile already
        if (turret != null)
        {
            Debug.Log("There is a turret here already!");
            return;
        }

        // Calls the method to build the turret on the tile
        turretManager.BuildTurrentOn(this);
    }
}
