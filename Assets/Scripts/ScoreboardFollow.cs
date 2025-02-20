using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ScoreboardFollow : MonoBehaviour
{
    public Transform xrOrigin; // Assign XR Origin (e.g., Camera or XR Rig)
    public Vector3 offset = new Vector3(0, 1.5f, 2f); // Adjust as needed

    void Update()
    {
        if (xrOrigin)
        {
            // Update position based on XR Origin + offset
            transform.position = xrOrigin.position + xrOrigin.forward * offset.z + xrOrigin.up * offset.y;

            // Face the player
            transform.LookAt(xrOrigin.position);
            
        }
    }
}