using UnityEngine;

public class GlitchScale : MonoBehaviour
{
    public float speed = 5f;
    public float maxScale = 2f;

    // A random offset so if you put this on 10 cubes, they don't all glitch at the exact same time
    private float randomSeed;

    void Start()
    {
        randomSeed = Random.Range(0f, 100f);
    }

    void Update()
    {
        // Perlin noise generates a smooth, random value between 0.0 and 1.0
        float noise = Mathf.PerlinNoise(Time.time * speed + randomSeed, 0f);

        float finalScale = 0.5f + (noise * maxScale);
        transform.localScale = new Vector3(finalScale, finalScale, finalScale);
    }
}