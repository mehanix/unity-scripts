using UnityEngine;
using UnityEngine.InputSystem;

public class HoverErosion : MonoBehaviour
{
    public float erodeSpeed = 1.5f;

    private Material myUniqueMaterial;
    private float currentErosion = 0f;

    void Start()
    {
        // Calling .material creates a private clone just for this cube
        myUniqueMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        bool isHovering = false;

        // 1. Check where the mouse is using the New Input System
        if (Mouse.current != null)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();

            // 2. Shoot an invisible laser from the camera through the mouse cursor
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            // 3. Did the laser hit anything? 
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // 4. Did it hit THIS specific cube?
                if (hit.transform == this.transform)
                {
                    isHovering = true;
                }
            }
        }

        // 5. If hovering, increase erosion. Otherwise, slowly heal.
        if (isHovering)
        {
            currentErosion += Time.deltaTime * erodeSpeed;
        }
        else
        {
            currentErosion -= Time.deltaTime * erodeSpeed;
        }

        // Keep it strictly between 0 (solid) and 1 (invisible)
        currentErosion = Mathf.Clamp(currentErosion, 0f, 1f);

        // Apply it to the shader
        myUniqueMaterial.SetFloat("_ErosionLevel", currentErosion);
    }
}