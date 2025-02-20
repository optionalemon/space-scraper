using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportManager : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    public TeleportationProvider teleportationProvider;
    public InputHelpers.Button teleportButton = InputHelpers.Button.PrimaryButton;
    public XRController controller;
    public XRInteractorLineVisual lineVisual;
    public Gradient validTeleportGradient;
    public Gradient invalidTeleportGradient;

    
    void Update()
    {
        if (controller == null || teleportationProvider == null || rayInteractor == null)
            return;

        // Check if ray is pointing to a valid teleport location (TeleportationArea component)
        bool isValidTarget = rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) &&
                             hit.collider.GetComponentInParent<TeleportationArea>() != null;

        // Change the line color based on validity
        lineVisual.validColorGradient = isValidTarget ? validTeleportGradient : invalidTeleportGradient;

        // If teleport button is pressed and target is valid, teleport
        if (IsTeleportButtonPressed() && isValidTarget)
        {
            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = hit.point
            };
            teleportationProvider.QueueTeleportRequest(request);
        }
    }

    bool IsTeleportButtonPressed()
    {
        controller.inputDevice.IsPressed(teleportButton, out bool isPressed);
        return isPressed;
    }
}
