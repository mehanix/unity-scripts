using UnityEngine;
using UnityEngine.InputSystem; // Required for the new system

public class LookAtCursor : MonoBehaviour
{
    void Update()
    {
        // Safety check: make sure a mouse is actually connected
        if (Mouse.current == null) return;

        // 1. Get the 2D mouse position from the New Input System
        Vector2 mousePos2D = Mouse.current.position.ReadValue();

        // 2. Wrap it in a Vector3 and give it depth (Z axis)
        Vector3 mousePos = new Vector3(mousePos2D.x, mousePos2D.y, 15f);

        // 3. Convert screen pixels into a 3D world coordinate
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);

        // 4. Face that point
        transform.LookAt(target);
    }
}
