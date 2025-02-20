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
    
    void Update()
    {
        if (controller == null || teleportationProvider == null || rayInteractor == null)
            return;

        if (IsTeleportButtonPressed() && rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
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
