using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWaste : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Bullet")) 
        {
         
            if (hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);
            }

        
        }
    }
}