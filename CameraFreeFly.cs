using UnityEngine;
using UnityEngine.InputSystem;

public class FreeFlyCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 2f;
    
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        // Capture initial rotation
        Vector3 angles = transform.eulerAngles;
        rotationX = angles.y;
        rotationY = angles.x;
    }

    void Update()
    {
        if (Keyboard.current == null || Mouse.current == null) return;

        // 1. Look Around (Hold Right Mouse Button)
        if (Mouse.current.rightButton.isPressed)
        {
            Vector2 delta = Mouse.current.delta.ReadValue();
            rotationX += delta.x * lookSpeed * 0.1f;
            rotationY -= delta.y * lookSpeed * 0.1f;
            
            // Clamp vertical rotation so you don't flip upside down
            rotationY = Mathf.Clamp(rotationY, -80f, 80f);

            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);
        }

        // 2. Keyboard Movement (WASD / Arrows + Q/E for vertical)
        Vector3 moveDirection = Vector3.zero;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            moveDirection += transform.forward;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            moveDirection -= transform.forward;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveDirection += transform.right;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveDirection -= transform.right;
            
        // Vertical movement
        if (Keyboard.current.eKey.isPressed)
            moveDirection += Vector3.up;
        if (Keyboard.current.qKey.isPressed)
            moveDirection -= Vector3.up;

        // Apply movement smoothly
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
}
