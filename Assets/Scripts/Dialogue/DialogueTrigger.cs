using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private DialogueTextWriter dialogueWriter;
    public DialogueTextContainers dialogueContainer;
    private bool isDialogueActive = false;
    private bool hasMemoryTriggered = false;
    public bool hasMemory;
    public int currentTextLine = 0;

    private void Start()
    {
        dialogueBox.SetActive(false);
        currentTextLine = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!isDialogueActive)
        {
            if (!hasMemory && !hasMemoryTriggered) 
            {
                currentTextLine = 0;
                Invoke("ActivateDialogueBox", 0.3f);
            }
            else if (hasMemory && !hasMemoryTriggered)
            {
                currentTextLine = 0;
                Invoke("ActivateDialogueBox", 0.3f);
                hasMemoryTriggered = true;
            }    
            else if (hasMemoryTriggered)
            {
                return;
            }
        }
    }

    private void ActivateDialogueBox()
    {
        dialogueBox.SetActive(true);
        isDialogueActive = true;
        gameManager.isInCutscene = true;

        dialogueWriter.MessageRecieved(this, dialogueContainer);
    }

    public int GetCurrentTextLine() => currentTextLine;
    public void IncreaseTextLine() => currentTextLine++;

    public void DeactivateDialogueBox()
    {
        dialogueBox.SetActive(false);
        isDialogueActive = false;
        gameManager.isInCutscene = false;
    }
}
