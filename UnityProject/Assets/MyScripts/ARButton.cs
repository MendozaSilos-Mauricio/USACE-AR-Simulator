using UnityEngine;

public class PlayAudioButton : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayAudio()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void StopAudio()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }
}
