using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueTrigger trigger;
    public DialogueTextContainers dialogueContainer;
    private bool isDialogueActive = false;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private DialogueTextWriter dialogueWriter;

    private void Start()
    {
        trigger = this;
        dialogueBox.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!isDialogueActive)
        {
            ActivateDialogueBox();
        }
    }

    private void ActivateDialogueBox()
    {
        dialogueBox.SetActive(true);
        isDialogueActive = true;

        dialogueWriter.MessageRecieved(trigger, dialogueContainer);
    }

    public void DeactivateDialogueBox()
    {
        dialogueBox.SetActive(false);
        isDialogueActive = false;
    }
}
