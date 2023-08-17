using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjectOffscreen : MonoBehaviour
{
    [SerializeField] private SwitchObjectsOffScreen objectsOffScreen;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform targetObject;
    [SerializeField] private float screenBorder = 10f;
    private bool objectOffScreen = false;
    private bool objectChanged = false;
    private Vector4 targetScreenPos;

    private void Update()
    {
        DetectVisibilityFromCamera();
    }

    private void DetectVisibilityFromCamera()
    {
       if (!targetObject) return;

        targetScreenPos = cam.WorldToScreenPoint(targetObject.position);

        objectOffScreen = targetScreenPos.x <= screenBorder || targetScreenPos.x >= Screen.width || targetScreenPos.y <= screenBorder || targetScreenPos.y >= Screen.height;
        if (objectOffScreen)
        {
            if (!objectChanged)
            {
                objectsOffScreen.DeactivateObject();
                objectChanged = true;
            }

            //Debug.Log("OFFSCREEN");
        }
        else
        {
            objectChanged = false;
            //Debug.Log("VISIBLE");
        }
    }
}
