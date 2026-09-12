using UnityEngine;
// The material on the object must have "Emission" turned on in URP for the glow to work.
public class RandomNeonColor : MonoBehaviour
{
    public float glowIntensity = 3f;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            // Generate a random bright color
            Color randomColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.8f, 1f);

            // Apply it to the base color and the URP emission slot
            rend.material.color = randomColor;
            rend.material.SetColor("_EmissionColor", randomColor * glowIntensity);
        }
    }
}