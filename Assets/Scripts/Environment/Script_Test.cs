using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Test : MonoBehaviour
{
    public Script_Test otherObject;
    public bool isActive;
    public Rigidbody rb;

    public bool IsActive()
    {
        return isActive;
    }

    void Update()
    {
        if (isActive)
        {
            otherObject.isActive = false;
            rb.isKinematic = false;

            otherObject.transform.localPosition = transform.localPosition;
        }
        else
        {
            rb.isKinematic = true;
            otherObject.isActive = true;
        }
    }
}
