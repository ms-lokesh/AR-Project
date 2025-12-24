using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class SimpleARDebug : MonoBehaviour
{
    public ARTrackedImageManager imageManager;
    public TextMeshProUGUI debugText;

    void Start()
    {
        if (debugText != null)
            debugText.text = "AR Started - Scanning...";
    }

    void OnEnable()
    {
        if (imageManager != null)
            imageManager.trackedImagesChanged += OnImagesChanged;
    }

    void OnDisable()
    {
        if (imageManager != null)
            imageManager.trackedImagesChanged -= OnImagesChanged;
    }

    void OnImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        if (debugText == null) return;

        if (args.added.Count > 0)
        {
            debugText.text = "IMAGE FOUND: " + args.added[0].referenceImage.name;
        }
        
        if (args.updated.Count > 0)
        {
            debugText.text = "TRACKING: " + args.updated[0].referenceImage.name;
        }
    }
}
