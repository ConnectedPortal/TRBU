using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjectsOffScreen : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    public int objectNumber;
    private bool isObjectDeactivated = false;

    void Update()
    {
        ChangeArrayPosition();
    }

    private void ChangeArrayPosition()
    {
        if (isObjectDeactivated)
        {
            objectNumber++;
            if (objectNumber >= objects.Length)
            {
                objectNumber = 0;
            }

            ActivateObject();
        }
    }

    public void DeactivateObject()
    {
        objects[objectNumber].SetActive(false);
        isObjectDeactivated = true;
    }

    private void ActivateObject()
    {
        objects[objectNumber].SetActive(true);
        isObjectDeactivated = false;
    }
}
