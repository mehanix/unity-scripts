using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothFollowCursor : MonoBehaviour
{
    public float followSpeed = 3f; // Lower number = slower, more sluggish tracking
    public float depth = 15f; // Distance from camera

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mousePos2D = Mouse.current.position.ReadValue();
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos2D.x, mousePos2D.y, depth));

        // Lerp creates that smooth, delayed "catch up" effect
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);
    }
}