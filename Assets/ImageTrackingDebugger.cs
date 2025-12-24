
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ImageTrackingDebugger : MonoBehaviour
{
    public ARTrackedImageManager imageManager;
    public TextMeshProUGUI debugText;

    void OnEnable()
    {
        imageManager.trackedImagesChanged += OnTrackedImagesChanged;
        debugText.text = "AR started. Looking for image...";
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        if (args.added.Count > 0)
            debugText.text = "IMAGE DETECTED ✅";

        else if (args.updated.Count > 0)
            debugText.text = "IMAGE TRACKING 🔄";

        else if (args.removed.Count > 0)
            debugText.text = "IMAGE LOST ❌";
    }
}