/**
 * CursorCrush (MouseRaycastInteract.cs)
 * 
 * Description: Casts a ray from the mouse position and increases the mass of any target Rigidbody hit by the cursor.
 * Usage: Attach to a manager object or Main Camera. Ensure target objects have Collider and Rigidbody components. Requires Unity Input System.
 */
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorCrush : MonoBehaviour
{
    public float heavyMass = 1000f;

    void Update()
    {
        if (Mouse.current == null) return;

        // Shoot a ray from the mouse
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        // If the ray hits a collider...
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Look for a Rigidbody on the object we hit
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                // do something
                rb.mass = heavyMass;
            }
        }
    }
}
