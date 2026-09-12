using UnityEngine;
using UnityEngine.InputSystem;

public class MouseShake : MonoBehaviour
{
    public float shakeIntensity = 0.02f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        // Read how fast the mouse is moving this frame
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        float speed = mouseDelta.magnitude;

        if (speed > 1f)
        {
            // Vibrate based on mouse speed
            Vector3 chaos = Random.insideUnitSphere * speed * shakeIntensity;
            transform.position = originalPosition + chaos;
        }
        else
        {
            // Smoothly snap back to the original position when the mouse stops
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * 10f);
        }
    }
}