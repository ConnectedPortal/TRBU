using UnityEngine;

public class PortalCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private Transform inputPortal;
    [SerializeField] private Transform outputPortal;

    private void LateUpdate()
    {
        UpdatePositionandRotation();
    }

    private void UpdatePositionandRotation()
    {
        Vector3 playerOffsetFromPortal = playerCam.position - outputPortal.position;
        transform.position = inputPortal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(inputPortal.rotation, outputPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCamDirection = portalRotationalDifference * playerCam.forward;
        transform.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);
    }
}
