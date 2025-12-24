using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ImageTracker : MonoBehaviour
{
    public ARTrackedImageManager imageManager;
    public List<GameObject> arObjects;
    private Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>();

    void Start()
    {
        foreach (GameObject prefab in arObjects)
        {
            GameObject newObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newObject.SetActive(false);
            spawnedObjects[prefab.name] = newObject;
        }
    }

    void OnEnable()
    {
        imageManager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage tracked in args.added)
        {
            UpdateObject(tracked);
        }

        foreach (ARTrackedImage tracked in args.updated)
        {
            UpdateObject(tracked);
        }
    }

    void UpdateObject(ARTrackedImage tracked)
    {
        string imageName = tracked.referenceImage.name;

        if (spawnedObjects.ContainsKey(imageName))
        {
            GameObject obj = spawnedObjects[imageName];
            obj.transform.position = tracked.transform.position;
            obj.transform.rotation = tracked.transform.rotation;
            obj.SetActive(tracked.trackingState == TrackingState.Tracking);
        }
    }
}
