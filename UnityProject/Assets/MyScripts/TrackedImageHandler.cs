using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackedImageHandler : MonoBehaviour
{
    public GameObject prefabToSpawn;       // your AR content prefab
    public GameObject audioButtonCanvas;   // your world-space button

    private ARTrackedImageManager trackedImageManager;

    void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            // Spawn your AR object at the marker position
            Instantiate(prefabToSpawn, trackedImage.transform.position, trackedImage.transform.rotation);

            // Show the audio button
            audioButtonCanvas.SetActive(true);
        }

        foreach (var trackedImage in args.removed)
        {
            // Hide button when marker lost
            audioButtonCanvas.SetActive(false);
        }
    }
}
