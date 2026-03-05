using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ARButtonNarration : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // This gets called when the button is pressed
    public void ToggleAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
}
