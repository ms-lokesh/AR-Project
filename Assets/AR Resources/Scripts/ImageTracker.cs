using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ImageTracker : MonoBehaviour
{
    public ARTrackedImageManager imageManager;

    // Assign these in Inspector
    public GameObject heartPrefab;
    public GameObject mitochondriaPrefab;
    public GameObject brainPrefab;
    public GameObject kidneyPrefab;
    public GameObject skullPrefab;

    // Stores spawned models per image name
    private Dictionary<string, GameObject> spawnedModels = new Dictionary<string, GameObject>();

    void OnEnable()
    {
        if (imageManager != null)
            imageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        if (imageManager != null)
            imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage tracked in args.added)
            SpawnModel(tracked);

        foreach (ARTrackedImage tracked in args.updated)
            UpdateModel(tracked);

        foreach (ARTrackedImage tracked in args.removed)
            RemoveModel(tracked);
    }

    void SpawnModel(ARTrackedImage tracked)
    {
        string imageName = tracked.referenceImage.name;

        if (spawnedModels.ContainsKey(imageName))
            return;

        GameObject prefab = GetPrefabForImage(imageName);
        if (prefab == null)
            return;

        GameObject model = Instantiate(
            prefab,
            tracked.transform.position,
            tracked.transform.rotation
        );

        model.SetActive(tracked.trackingState == TrackingState.Tracking);
        spawnedModels.Add(imageName, model);
    }

    void UpdateModel(ARTrackedImage tracked)
    {
        string imageName = tracked.referenceImage.name;

        if (!spawnedModels.ContainsKey(imageName))
            return;

        GameObject model = spawnedModels[imageName];

        if (tracked.trackingState == TrackingState.Tracking)
        {
            model.SetActive(true);
            model.transform.position = tracked.transform.position;
            model.transform.rotation = tracked.transform.rotation;
        }
        else
        {
            model.SetActive(false);
        }
    }

    void RemoveModel(ARTrackedImage tracked)
    {
        string imageName = tracked.referenceImage.name;

        if (!spawnedModels.ContainsKey(imageName))
            return;

        Destroy(spawnedModels[imageName]);
        spawnedModels.Remove(imageName);
    }

    // 🔑 Map image names → prefabs
    GameObject GetPrefabForImage(string imageName)
    {
        switch (imageName)
        {
            case "heart":
                return heartPrefab;

            case "mitochondria":
                return mitochondriaPrefab;

            case "brain":
                return brainPrefab;

            case "kidney":
                return kidneyPrefab;

            case "skull":
                return skullPrefab;

            default:
                return null;
        }
    }
}
