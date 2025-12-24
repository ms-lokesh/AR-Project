using UnityEngine;

public class CircuitManager : MonoBehaviour
{
    public Material OnSwitchMaterial;
    public Material OnBulbMaterial;
    public Material OffSwitchMaterial;
    public Material OffBulbMaterial;
    public Renderer switchRenderer;
    public Renderer bulbRenderer;
    public bool On;

    private Camera arCamera;

    void Start()
    {
        // Cache the AR camera reference
        arCamera = Camera.main;
        
        // Validate required components
        if (arCamera == null)
        {
            Debug.LogError("Main Camera not found! Make sure your AR camera is tagged as 'MainCamera'.");
        }
        
        if (switchRenderer == null || bulbRenderer == null)
        {
            Debug.LogError("Switch or Bulb Renderer not assigned in CircuitManager!");
        }
        
        if (OnSwitchMaterial == null || OnBulbMaterial == null || 
            OffSwitchMaterial == null || OffBulbMaterial == null)
        {
            Debug.LogError("One or more materials not assigned in CircuitManager!");
        }
    }

    void Update()
    {
        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check for both Began and Ended phases to make it more responsive
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Ended)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Use LayerMask.GetMask("Default") if your object is on the Default layer
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if we hit this object's collider
                    if (hit.collider.gameObject == gameObject)
                    {
                        ChangeMaterial();
                    }
                }
            }
        }
    }

    void ChangeMaterial()
    {
        // Toggle the state first
        On = !On;

        Debug.Log($"Switch state changed to: {On}");

        // Apply materials based on current state
        if (switchRenderer != null && bulbRenderer != null)
        {
            if (On)
            {
                if (OnBulbMaterial != null) bulbRenderer.material = OnBulbMaterial;
                if (OnSwitchMaterial != null) switchRenderer.material = OnSwitchMaterial;
            }
            else
            {
                if (OffBulbMaterial != null) bulbRenderer.material = OffBulbMaterial;
                if (OffSwitchMaterial != null) switchRenderer.material = OffSwitchMaterial;
            }
        }
    }
}