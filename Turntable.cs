/**
 * AutoRotate (Turntable.cs)
 * 
 * Description: Continuously rotates the GameObject around specified local axes at a constant framerate-independent speed.
 * Usage: Attach to any 3D object transform (turntables, collectibles, background elements). Adjust rotationSpeed in the Inspector.
 */
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50f, 0); // Exposes X, Y, Z to the Inspector

    void Update()
    {
        // Rotates smoothly regardless of frame rate
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}