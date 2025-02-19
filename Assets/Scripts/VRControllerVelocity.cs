using UnityEngine;

public class VRControllerVelocity : MonoBehaviour
{
    private Vector3 previousPosition;
    private Quaternion previousRotation;
    
    public Vector3 Velocity { get; private set; }
    public Vector3 AngularVelocity { get; private set; }

    void Start()
    {
        previousPosition = transform.position;
        previousRotation = transform.rotation;
    }

    void Update()
    {
        // Calculate Velocity (Linear Movement)
        Velocity = (transform.position - previousPosition) / Time.deltaTime;

        // Calculate Angular Velocity (Rotational Movement)
        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(previousRotation);
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);
        AngularVelocity = (axis * angle * Mathf.Deg2Rad) / Time.deltaTime;

        // Store previous frame values
        previousPosition = transform.position;
        previousRotation = transform.rotation;
    }
}
