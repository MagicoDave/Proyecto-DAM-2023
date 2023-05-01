using UnityEngine;

// Script to manage Tile logic
public class TileScript : MonoBehaviour
{

    private GameObject turret;
    private Vector3 positionOffset = new Vector3(0, 0.5f, 0);

    private Color startColor;
    public Color hoverColor;

    private Renderer rend;

    // Gets default color and renderer on start
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Change color on mouse enter for user readability
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    // Back to default color on mouse exit for user readability
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    // Builds a tower on the clicked Tile
    private void OnMouseDown()
    {

        // Checks if there is a turret in this tile already
        if (turret != null)
        {
            Debug.Log("There is a turret here already!");
            return;
        }

        // Build a turret
        GameObject turretToBuild = TurretManager.instance.getTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation); 
    }
}
