using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private DialogueTextWriter dialogueWriter;

    [Header("Dialogue")]
    public DialogueTextContainers dialogueContainer;
    private bool isDialogueActive = false;
    private bool hasMemoryTriggered = false;
    public bool hasMemory = false;
    public int currentTextLine = 0;

    [Header("Cutscene")]
    public bool willFocusOnObject = false;
    [SerializeField] private GameObject targetObject;

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

        if (willFocusOnObject)
        {
            gameManager.focusOnObject = true;
            gameManager.objectTarget = targetObject;
        }

        dialogueWriter.MessageRecieved(this, dialogueContainer);
    }

    public int GetCurrentTextLine() => currentTextLine;
    public void IncreaseTextLine() => currentTextLine++;

    public void DeactivateDialogueBox()
    {
        dialogueBox.SetActive(false);
        isDialogueActive = false;

        gameManager.isInCutscene = false;
        gameManager.focusOnObject = false;
    }
}
