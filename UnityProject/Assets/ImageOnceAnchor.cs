using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageOnceAnchor : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public GameObject contentPrefab;           // WetlandsTableTop
    public ARAnchorManager anchorManager;      // XR Origin’s ARAnchorManager

    // Internal state
    private ARTrackedImageManager _imgMgr;
    private readonly Dictionary<string, GameObject> _spawnedByGuid = new();
    private readonly Dictionary<string, ARAnchor> _anchorsByGuid = new();

    void Awake()
    {
        _imgMgr = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        _imgMgr.trackedImagesChanged += OnTrackedImagesChanged;
        // Reset AR session between runs so you start clean
        // var session = FindObjectOfType<ARSession>();
        // if (session) session.Reset();
    }

    void OnDisable()
    {
        _imgMgr.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        // When a new image is detected, create ONE anchor + ONE content
        foreach (var added in args.added)
        {
            CreateIfNeeded(added);
            UpdateVisibility(added);
        }

        // When an existing image updates, DO NOT keep re-parenting or re-setting pose.
        // Only toggle visibility based on tracking state. Let the anchor keep it stable.
        foreach (var updated in args.updated)
        {
            UpdateVisibility(updated);
        }

        // If image is removed or tracking is lost entirely, we can hide content (but keep anchor).
        foreach (var removed in args.removed)
        {
            var guid = removed.referenceImage.guid.ToString();
            if (_spawnedByGuid.TryGetValue(guid, out var go))
                go.SetActive(false);
        }
    }

    private void CreateIfNeeded(ARTrackedImage trackedImage)
    {
        var guid = trackedImage.referenceImage.guid.ToString();
        if (_spawnedByGuid.ContainsKey(guid)) return;

        // Add or get an anchor on the tracked image’s transform
        // (This makes the anchor live at the image center.)
        var anchor = trackedImage.GetComponent<ARAnchor>();
        if (anchor == null)
        {
            // Prefer AddComponent over AnchorManager.AddAnchor for image-based anchors
            // so it stays attached to the image’s native anchor when available.
            anchor = trackedImage.gameObject.AddComponent<ARAnchor>();
        }

        // Instantiate content as a child of the anchor (one time)
        var content = Instantiate(contentPrefab, anchor.transform);
        content.transform.localPosition = Vector3.zero;
        content.transform.localRotation = Quaternion.identity;

        // match scale to the physical image width if you want it to fit the marker exactly
        // float imageWidthMeters = trackedImage.referenceImage.size.x;
        // float desiredWidthForContent = 0.20f; // set this to your prefab’s intended width in meters
        // float scale = imageWidthMeters / desiredWidthForContent;
        // content.transform.localScale = Vector3.one * scale;

        _spawnedByGuid[guid] = content;
        _anchorsByGuid[guid] = anchor;
    }

    private void UpdateVisibility(ARTrackedImage trackedImage)
    {
        var guid = trackedImage.referenceImage.guid.ToString();
        if (_spawnedByGuid.TryGetValue(guid, out var content))
        {
            // Only show content when the image is currently tracked
            bool visible = trackedImage.trackingState == TrackingState.Tracking;
            content.SetActive(visible);
        }
    }
}
