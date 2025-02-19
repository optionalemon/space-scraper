using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class VRGrab : MonoBehaviour
{

    private bool grabbing = false;
    private GameObject grabbedObject;

    
    public InputActionReference grabAction;
    public InputActionProperty haptic;
    
    public float _amplitude = 1.0f;
    public float _frequency = 50.0f;
    public float _duration = 0.1f;

    // public InputActionProperty controllerVelocity;
    // public InputActionProperty controllerAngularVelocity;

    public float grabRadius;
    public LayerMask grabMask;

    void Start()
    {
        if (grabAction == null || haptic == null)
            return;

        grabAction.action.Enable();
        haptic.action.Enable();

        grabAction.action.performed += OnActionPerformed;
        grabAction.action.canceled += OnActionCanceled;
    }

    void OnActionPerformed(InputAction.CallbackContext ctx)
    {
        var control = grabAction.action.activeControl;
        if (control == null)
            return;

        OpenXRInput.SendHapticImpulse(haptic.action, _amplitude, _frequency, _duration, control.device);
        GrabObject();
    }

    void OnActionCanceled(InputAction.CallbackContext ctx)
    {
        DropObject();
    }

    void GrabObject()
    {
        grabbing = true;
        RaycastHit[] hits;

        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);

        if (hits.Length > 0)
        {
            int closestHit = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].distance < hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }

            grabbedObject = hits[closestHit].transform.gameObject;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            grabbedObject.transform.position = transform.position;
            grabbedObject.transform.parent = transform;
        }
    }

    void DropObject()
    {
        grabbing = false;
        if (grabbedObject != null)
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            VRControllerVelocity controllerVelocity = GetComponent<VRControllerVelocity>();
            if (controllerVelocity != null)
            {
                grabbedObject.GetComponent<Rigidbody>().velocity = controllerVelocity.Velocity * 1.5f;
                grabbedObject.GetComponent<Rigidbody>().angularVelocity = controllerVelocity.AngularVelocity;
            }
            grabbedObject = null;
        }
    }
}
