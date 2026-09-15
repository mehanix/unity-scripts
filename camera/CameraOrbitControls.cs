/**
 * SimpleOrbit (CameraOrbitControls.cs)
 * 
 * Description: Enables orbiting a camera around a target Transform (or world origin) by holding Right Mouse Button and dragging.
 * Usage: Attach to a Main Camera. Assign a target Transform in the Inspector (leave null to orbit world origin). Requires Unity Input System.
 */
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleOrbit : MonoBehaviour
{
    [Tooltip("The object in the center of the room you want to look at. Leave empty to look at Vector3.zero.")]
    public Transform target; 
    
    public float orbitSpeed = 5f;
    public float distance = 10f;

    private float currentX = 0f;
    private float currentY = 0f;

    void LateUpdate()
    {
        if (Mouse.current == null) return;

        // Hold right-click and drag to orbit
        if (Mouse.current.rightButton.isPressed)
        {
            Vector2 delta = Mouse.current.delta.ReadValue();
            currentX += delta.x * orbitSpeed * 0.02f;
            currentY -= delta.y * orbitSpeed * 0.02f;
            
            // Clamp the vertical look so the camera doesn't flip upside down
            currentY = Mathf.Clamp(currentY, -85f, 85f);
        }

        // Determine the target position (defaults to center of the world if unassigned)
        Vector3 targetPosition = (target != null) ? target.position : Vector3.zero;

        // Calculate rotation and position
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 position = targetPosition - (rotation * Vector3.forward * distance);

        // Apply it to the camera
        transform.rotation = rotation;
        transform.position = position;
    }
}
