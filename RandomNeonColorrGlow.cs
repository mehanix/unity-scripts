/**
 * RandomNeonColor (RandomNeonColorrGlow.cs)
 * 
 * Description: Assigns a random vibrant HSV color and matching URP emission glow intensity to the object's material on start.
 * Usage: Attach to a GameObject with a Renderer. The material must use a shader with "_EmissionColor" enabled (e.g. URP/Lit). Adjust glowIntensity in Inspector.
 */
using UnityEngine;
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