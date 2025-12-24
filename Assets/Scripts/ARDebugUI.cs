using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class ARDebugUI : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI trackedImagesText;
    public Button scanButton;
    public GameObject debugPanel;

    [Header("AR References")]
    public ARSession arSession;
    public ARTrackedImageManager trackedImageManager;
    public ARCameraManager cameraManager;

    private int trackedImageCount = 0;
    private string lastDetectedImage = "None";
    private bool isScanning = false;

    void Start()
    {
        if (scanButton != null)
            scanButton.onClick.AddListener(OnScanButtonPressed);

        if (arSession == null)
            arSession = FindObjectOfType<ARSession>();
        if (trackedImageManager == null)
            trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        if (cameraManager == null)
            cameraManager = FindObjectOfType<ARCameraManager>();

        UpdateStatus("AR Initialized. Point camera at image.");
    }

    void OnEnable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void Update()
    {
        UpdateDebugInfo();
    }

    void OnScanButtonPressed()
    {
        isScanning = !isScanning;

        UpdateStatus(isScanning ? "🔍 Scanning..." : "Scanning stopped");

        if (scanButton != null)
            scanButton.GetComponentInChildren<TextMeshProUGUI>().text =
                isScanning ? "Stop Scanning" : "Start Scanning";
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var img in args.added)
        {
            trackedImageCount++;
            lastDetectedImage = img.referenceImage.name;
            UpdateStatus($"✅ DETECTED: {lastDetectedImage}");
        }

        foreach (var img in args.updated)
        {
            if (img.trackingState == TrackingState.Tracking)
            {
                lastDetectedImage = img.referenceImage.name;
                UpdateStatus($"👁️ TRACKING: {lastDetectedImage}");
            }
        }

        foreach (var img in args.removed)
        {
            trackedImageCount--;
            UpdateStatus($"❌ Lost: {img.referenceImage.name}");
        }
    }

    void UpdateDebugInfo()
    {
        if (trackedImagesText == null) return;

        string info =
            $"📊 AR Status\n" +
            $"Session: {(arSession != null && arSession.enabled ? "✅" : "❌")}\n" +
            $"Camera: {(cameraManager != null && cameraManager.enabled ? "✅" : "❌")}\n" +
            $"Image Manager: {(trackedImageManager != null && trackedImageManager.enabled ? "✅" : "❌")}\n" +
            $"Library: {(trackedImageManager?.referenceLibrary != null ? "✅" : "❌")}\n" +
            $"Images in Library: {(trackedImageManager?.referenceLibrary?.count ?? 0)}\n" +
            $"Tracked Images: {trackedImageCount}\n" +
            $"Last Detected: {lastDetectedImage}";

        trackedImagesText.text = info;
    }

    void UpdateStatus(string msg)
    {
        if (statusText != null)
            statusText.text = msg;

        Debug.Log("[AR Debug] " + msg);
    }

    // ✅ FIXED VERSION (NO foreach)
    public void CheckARSetup()
    {
        Debug.Log("=== AR SETUP CHECK ===");

        if (trackedImageManager == null || trackedImageManager.referenceLibrary == null)
        {
            Debug.Log("❌ Image Library missing");
            return;
        }

        var library = trackedImageManager.referenceLibrary;
        Debug.Log($"Images in Library: {library.count}");

        for (int i = 0; i < library.count; i++)
        {
            XRReferenceImage img = library[i];
            Debug.Log($"- {img.name} | Size: {img.size}");
        }

        Debug.Log("=====================");
    }
}