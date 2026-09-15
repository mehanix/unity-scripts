/**
 * Lifespan (TimeToLive.cs)
 * 
 * Description: Automatically destroys the attached GameObject after a specified duration (time to live) in seconds.
 * Usage: Attach to temporary GameObjects like spawned projectiles, floating text, or particles. Adjust timeToLive in the Inspector.
 */
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    public float timeToLive = 5f;

    void Start()
    {
        // The Destroy function has a built-in timer argument!
        Destroy(gameObject, timeToLive);
    }
}