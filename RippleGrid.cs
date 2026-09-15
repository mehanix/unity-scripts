/**
 * DistanceRipple (RippleGrid.cs)
 * 
 * Description: Modifies the vertical scale (Y) of the GameObject using a sine wave relative to its distance from the mouse cursor to produce a ripple effect.
 * Usage: Attach to objects arranged in a grid or matrix. Adjust rippleHeight in the Inspector. Requires Unity Input System and Main Camera.
 */
using UnityEngine;
using UnityEngine.InputSystem;

public class DistanceRipple : MonoBehaviour
{
    public float rippleHeight = 3f;
    private float originalY;

    void Start()
    {
        originalY = transform.localScale.y;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mousePos2D = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos2D.x, mousePos2D.y, 15f));

        // 1. Calculate how far this specific cube is from the mouse
        float distance = Vector3.Distance(transform.position, mouseWorldPos);

        // 2. Use a Sine wave mixed with the distance to create a rolling ripple
        float wave = Mathf.Sin(Time.time * 5f - distance);

        // 3. Only ripple if the mouse is somewhat close (e.g., within 5 units)
        if (distance < 5f)
        {
            float newY = originalY + (wave * rippleHeight);
            transform.localScale = new Vector3(transform.localScale.x, newY, transform.localScale.z);
        }
        else
        {
            // Smoothly return to normal
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, originalY, transform.localScale.z), Time.deltaTime * 5f);
        }
    }
}