using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionUIManager : MonoBehaviour, IObserver
{
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private string defaultInteractionText = "Press E to Interact";

    private void Start()
    {
        interactionText.text = string.Empty;
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable is null)
        {
            return;
        }
        else
        {
            interactable.Subscribe(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable is null)
        {
            return;
        }
        else
        {
            interactionText.text = string.Empty;
            interactable.Unsubscribe(this);
        }
    }

    public void Notify(IInteractable interactable)
    {
        interactionText.text = interactable.GetInteractionText();
        if (interactionText.text == string.Empty)
        {
            interactionText.text = defaultInteractionText;
        }
    }
}

public interface IInteractable
{
    public string GetInteractionText();

    public void Subscribe(IObserver observer);
    public void Unsubscribe(IObserver observer);
}

public interface IObserver
{
    public void Notify(IInteractable interactable);
}