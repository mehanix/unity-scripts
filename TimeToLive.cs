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