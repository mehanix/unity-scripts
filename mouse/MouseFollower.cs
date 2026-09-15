/**
 * FollowCursor (MouseFollower.cs)
 * 
 * Description: Instantly snaps the GameObject position to match the mouse cursor's 3D position projected into the world.
 * Usage: Attach to any GameObject transform. Set depthFromCamera in the Inspector. Requires Unity Input System and Main Camera.
 */
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCursor : MonoBehaviour
{
    [Tooltip("How far away from the camera the object should hover")]
    public float depthFromCamera = 10f; 

    void Update()
    {
        if (Mouse.current == null) return;

        // 1. Get the 2D mouse position
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // 2. Convert it to 3D space, using the depth to push it out into the room
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depthFromCamera));

        // 3. Move this GameObject to that exact spot
        transform.position = worldPos;
    }
}
