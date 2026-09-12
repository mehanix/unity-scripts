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