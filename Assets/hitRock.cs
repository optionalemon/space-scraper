using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSound : MonoBehaviour
{
    public AudioClip hitSound; 
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); 
        audioSource.playOnAwake = false; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Space Waste Small")
        {
         
            if (hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);
            }

            
            Destroy(gameObject, hitSound.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
