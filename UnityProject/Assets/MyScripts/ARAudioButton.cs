// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// [RequireComponent(typeof(AudioSource))]
// public class ARAudioButton : MonoBehaviour
// {
//     public Button playButton;       // Assign the Button in Inspector
//     public AudioClip infoClip;      // Assign your .mp3 or .wav clip

//     private AudioSource audioSource;

//     void Start()
//     {
//         audioSource = GetComponent<AudioSource>();
//         playButton.onClick.AddListener(PlayAudio);
//     }

//     void PlayAudio()
//     {
//         if (!audioSource.isPlaying)
//         {
//             audioSource.clip = infoClip;
//             audioSource.Play();
//             playButton.interactable = true;  // Disable during playback
//             Invoke(nameof(EnableButton), infoClip.length);
//         }
//     }

//     void EnableButton()
//     {
//         playButton.interactable = true;
//     }
// }
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ARAudioButton : MonoBehaviour, IPointerClickHandler
{
    public Button playButton;
    public AudioClip infoClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (playButton != null)
            playButton.onClick.AddListener(PlayAudio);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // This lets you click in Play Mode or tap in AR
        PlayAudio();
    }

    void PlayAudio()
    {
        if (!audioSource.isPlaying && infoClip != null)
        {
            audioSource.clip = infoClip;
            audioSource.Play();
            if (playButton != null)
                playButton.interactable = false;
            Invoke(nameof(EnableButton), infoClip.length);
        }
    }

    void EnableButton()
    {
        if (playButton != null)
            playButton.interactable = true;
    }
}
