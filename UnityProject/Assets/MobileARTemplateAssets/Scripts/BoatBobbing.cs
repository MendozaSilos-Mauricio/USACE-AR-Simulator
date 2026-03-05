using UnityEngine;

/// <summary>
/// This script makes the GameObject bob up and down using a sine wave.
/// Attach it to the boat object you want to animate.
/// </summary>
public class BoatBobbing : MonoBehaviour
{
    [Header("Bobbing Settings")]
    [Tooltip("The speed of the bobbing motion.")]
    public float bobSpeed = 1.0f;

    [Tooltip("How high and low the boat will bob from its starting position.")]
    public float bobHeight = 0.5f;

    // The boat's starting position, stored when the game begins.
    private Vector3 startPosition;

    /// <summary>
    /// Called once when the script is first enabled.
    /// </summary>
    void Start()
    {
        // Store the initial position of the boat.
        // We will calculate the bobbing offset from this position.
        startPosition = transform.position;
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        // 1. Calculate the new Y position using a Sine wave.
        // Mathf.Sin() returns a value that smoothly moves between -1 and 1.
        // Time.time * bobSpeed controls how fast we move along the sine wave.
        // We multiply the result by bobHeight to control the amplitude (how high/low it goes).

        float newY = startPosition.y + (Mathf.Sin(Time.time * bobSpeed) * bobHeight);

        // 2. Apply the new position.
        // We create a new Vector3 using the original X and Z positions,
        // but with our new calculated Y position.
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}