using UnityEngine;

// Camera movement logic and controls
public class CameraControllerScript : MonoBehaviour
{
    private float panBorderHeightThickness = Screen.height / 30;
    private float panBorderWidthThickness = Screen.width / 30;

    private bool allowMovement = true;

    [Header("Movement speed")]
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;

    [Header("Camera boundaries")]
    public float minZoom = 10f;
    public float maxZoom = 80f;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    // Update is called once per frame
    // Check for user inputs to control the camera
    void Update()
    {

        if (GameStateManager.gameOver)
        {
            this.enabled = false;
            return;
        }

        // Esc key toggles camera movement
        if (Input.GetKeyDown(KeyCode.L))
        {
            allowMovement = !allowMovement;
        }

        // If camera movement is disallowed, 
        if (!allowMovement)
        {
            return;
        }

        // If w is pressed or mouse is pushing at the top of the screen, camera moves forward
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderHeightThickness)
        {
            // Space.World is used to make the movement relative
            // to the object in the world and not the direction its looking
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        // If s is pressed or mouse is pushing at the bottom of the screen, camera moves back
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderHeightThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        // If d is pressed or mouse is pushing at the right of the screen, camera moves right
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderWidthThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        // If a is pressed or mouse is pushing at the left of the screen, camera moves left
        if (Input.GetKey("a") || Input.mousePosition.x <=  panBorderWidthThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        // Gets the mouse scroll input, the position and the zoom movement
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime * 1000;
        // Restrain the zoom (y) value to the constrains
        pos.y = Mathf.Clamp(pos.y, minZoom, maxZoom);
        //Restrain the z value to the constrains
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        //Restrain the x value to the constrains
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        // Zooms the camera to the new value
        transform.position = pos;

    }
}
