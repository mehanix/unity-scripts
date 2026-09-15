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
