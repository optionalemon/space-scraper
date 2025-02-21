using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public AudioSource audioSource; // The AudioSource component
    public AudioClip grabSound;     // The sound to play when grabbing

    // Call this method when an object is grabbed
    void OnGrab()
    {
        if (audioSource != null && grabSound != null)
        {
            audioSource.PlayOneShot(grabSound);
        }
    }
}
