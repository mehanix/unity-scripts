using UnityEngine;
using UnityEngine.InputSystem;

public class CameraVertigo : MonoBehaviour
{
    public float normalFOV = 60f;
    public float panicFOV = 20f; // Lower number = extreme zoom
    public float warpSpeed = 5f;

    void Update()
    {
        if (Keyboard.current == null) return;

        // Decide our target FOV based on if Spacebar is held down
        float targetFOV = Keyboard.current.spaceKey.isPressed ? panicFOV : normalFOV;

        // Smoothly glide the camera's view toward that target
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetFOV, Time.deltaTime * warpSpeed);
    }
}
