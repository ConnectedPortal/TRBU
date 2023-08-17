using System;
using UnityEngine;

public class PortalTextureFromCamera : MonoBehaviour
{
    [SerializeField] private Camera portalCam_A;
    [SerializeField] private Material portalCamMaterial_A;

    [SerializeField] private Camera portalCam_B;
    [SerializeField] private Material portalCamMaterial_B;
    private const Int32 renderDepth = 24;

    private void Start()
    {
        ApplyPortalTexture(portalCam_A, portalCamMaterial_A);
        ApplyPortalTexture(portalCam_B, portalCamMaterial_B);
    }

    private void ApplyPortalTexture(Camera cam, Material material)
    {
        cam.targetTexture?.Release(); //if not a null value

        cam.targetTexture = new RenderTexture(Screen.width, Screen.height, renderDepth);
        material.mainTexture = cam.targetTexture;
    }
}
