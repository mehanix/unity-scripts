/**
 * MouseShockwave (ClickExplosion.cs)
 * 
 * Description: Triggers a 3D explosion force at the raycast hit point when left-clicking, blasting nearby Rigidbodies outward.
 * Usage: Attach to a manager GameObject or Main Camera. Ensure scene objects have Rigidbody and Collider components. Requires Unity Input System.
 */
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseShockwave : MonoBehaviour
{
    public float blastRadius = 15f;
    public float blastForce = 800f;

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Find exactly where the user clicked in 3D space
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Grab every object inside a sphere around the click
                Collider[] hitObjects = Physics.OverlapSphere(hit.point, blastRadius);
                foreach (Collider obj in hitObjects)
                {
                    Rigidbody rb = obj.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        // Violently launch them outward
                        rb.AddExplosionForce(blastForce, hit.point, blastRadius);
                    }
                }
            }
        }
    }
}
