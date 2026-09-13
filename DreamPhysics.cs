using UnityEngine;

public class DreamPhysics : MonoBehaviour
{
    // 1 is normal speed. 0.2 is extreme slow motion.
    public float timeSpeed = 0.2f;

    // We can also lower gravity so it falls like it's underwater
    public float dreamGravity = -2f; // Normal is -9.81

    void Start()
    {
        // 1. Slow down the entire Unity engine (graphics and physics)
        Time.timeScale = timeSpeed;

        // 2. Override the global gravity
        Physics.gravity = new Vector3(0, dreamGravity, 0);
    }

    void OnDestroy()
    {
        // Safety cleanup: Put time back to normal when we stop the game!
        Time.timeScale = 1f;
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }
}