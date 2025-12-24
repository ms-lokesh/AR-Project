using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARVisualFeedback : MonoBehaviour
{
    [Header("Visual Feedback")]
    public GameObject detectionIndicator;
    public Color trackingColor = Color.green;
    public Color limitedColor = Color.yellow;
    public Color notTrackingColor = Color.red;
    
    private ARTrackedImageManager trackedImageManager;
    private Material indicatorMaterial;

    void Start()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        
        if (detectionIndicator != null)
        {
            var renderer = detectionIndicator.GetComponent<Renderer>();
            if (renderer != null)
            {
                indicatorMaterial = renderer.material;
            }
            detectionIndicator.SetActive(false);
        }
    }

    void OnEnable()
    {
        if (trackedImageManager != null)
        {
            trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }
    }

    void OnDisable()
    {
        if (trackedImageManager != null)
        {
            trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            ShowFeedback(trackedImage);
        }

        foreach (var trackedImage in args.updated)
        {
            ShowFeedback(trackedImage);
        }

        foreach (var trackedImage in args.removed)
        {
            if (detectionIndicator != null)
            {
                detectionIndicator.SetActive(false);
            }
        }
    }

    void ShowFeedback(ARTrackedImage trackedImage)
    {
        if (detectionIndicator == null) return;

        detectionIndicator.SetActive(true);
        detectionIndicator.transform.position = trackedImage.transform.position;
        detectionIndicator.transform.rotation = trackedImage.transform.rotation;

        if (indicatorMaterial != null)
        {
            switch (trackedImage.trackingState)
            {
                case UnityEngine.XR.ARSubsystems.TrackingState.Tracking:
                    indicatorMaterial.color = trackingColor;
                    break;
                case UnityEngine.XR.ARSubsystems.TrackingState.Limited:
                    indicatorMaterial.color = limitedColor;
                    break;
                default:
                    indicatorMaterial.color = notTrackingColor;
                    break;
            }
        }
    }
}
