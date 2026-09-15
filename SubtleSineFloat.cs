/**
 * OrganicFloat (SubtleSineFloat.cs)
 * 
 * Description: Provides a gentle bob up and down movement along the Y axis using a sine wave to keep scene objects dynamic.
 * Usage: Attach to any 3D or 2D object. Configure floatSpeed and floatHeight in the Inspector.
 */
using UnityEngine;

public class OrganicFloat : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave based on time
        float newY = startPos.y + (Mathf.Sin(Time.time * floatSpeed) * floatHeight);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
