using UnityEngine;
using UnityEngine.InputSystem;

public class PeripheralDissolve : MonoBehaviour
{
    [Tooltip("How far away the mouse needs to be (in pixels) for the object to be fully visible.")]
    public float safeDistance = 600f;

    private Material myMaterial;

    void Start()
    {
        // Calling .material creates a private clone just for this object
        myMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        // 1. Get the 2D mouse pixel coordinates on the monitor
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // 2. Translate the 3D object's position into 2D screen pixels
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 objectPos2D = new Vector2(screenPos.x, screenPos.y);

        // 3. Measure the distance between the mouse and the object
        float distance = Vector2.Distance(mousePos, objectPos2D);

        // 4. Calculate the erosion amount. 
        // If distance is 0, erosion is 1 (fully dissolved). 
        // If distance >= safeDistance, erosion is 0 (fully solid).
        float erosionAmount = 1f - (distance / safeDistance);

        // 5. Clamp the value strictly between 0 and 1
        erosionAmount = Mathf.Clamp(erosionAmount, 0f, 1f);

        // 6. Send the data to our Shader Graph!
        myMaterial.SetFloat("_ErosionLevel", erosionAmount);
    }
}