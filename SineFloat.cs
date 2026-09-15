/**
 * OrganicFloat (SineFloat.cs)
 * 
 * Description: Smoothly bobs the GameObject up and down along the Y axis using a mathematical sine wave.
 * Usage: Attach to any 3D or 2D GameObject transform. Tweak floatSpeed and floatHeight in the Inspector.
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