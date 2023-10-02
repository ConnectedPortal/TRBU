using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    private List<IObserver> observers = new List<IObserver>();

    private bool doorActive = true;
    private bool doorOpened = false;
    [SerializeField] private Animator controller;
    [SerializeField] private string interactionOpenText = "Press E to Open Door";
    [SerializeField] private string interactionClosedText = "Press E to Close Door";

    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && doorActive)
            {
                if(!doorOpened)
                {
                    OpenDoor(); 
                }
                else
                {
                    CloseDoor();
                }

                NotifyAll();
                StartCoroutine("MinimumWait");
            }
        }
    }

    private IEnumerator MinimumWait()
    {
        doorActive = false;
        yield return new WaitForSeconds(1f);
        //yield return null;
        doorActive = true;
    }

    private void OpenDoor()
    {
        doorOpened = true;
        controller?.SetTrigger("Open");
    }

    private void CloseDoor()
    {
        doorOpened = false;
        controller?.SetTrigger("Closed");
    }

    public string GetInteractionText()
    {
        return !doorOpened ? interactionOpenText : interactionClosedText;
    }

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
        NotifyAll();
    }

    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyAll()
    {
        foreach(var observer in observers)
        {
            observer.Notify(this);
        }
    }
}
