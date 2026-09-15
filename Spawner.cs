/**
 * ContinuousSpawner (Spawner.cs)
 * 
 * Description: Continuously instantiates a specified prefab object at a fixed time interval with random spatial position offsets.
 * Usage: Attach to a spawner transform. Drag a prefab into objectToSpawn and adjust spawnRateSeconds and randomOffset in the Inspector.
 */
using UnityEngine;

public class ContinuousSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRateSeconds = 1f;
    public Vector3 randomOffset = new Vector3(2f, 0f, 2f); // Adds chaos to the spawn location

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRateSeconds)
        {
            // Calculate a random position around the spawner
            Vector3 spawnPos = transform.position + new Vector3(
                Random.Range(-randomOffset.x, randomOffset.x),
                Random.Range(-randomOffset.y, randomOffset.y),
                Random.Range(-randomOffset.z, randomOffset.z)
            );

            Instantiate(objectToSpawn, spawnPos, Random.rotation);
            timer = 0f;
        }
    }
}