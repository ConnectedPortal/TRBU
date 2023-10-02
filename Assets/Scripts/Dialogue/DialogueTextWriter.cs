using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTextWriter : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    public DialogueTextContainers dialogueContainer;
    [SerializeField] private TextMeshProUGUI dialogueText;
    //private int index = 0;
    public bool isDialogueFinished = false;
    private bool firstLineWritten = false;

    private void Start()
    {
        RestartText();
    }

    private void RestartText()
    {
        dialogueText.text = string.Empty;
        firstLineWritten = false;
        //index = 0;
    }

    public void MessageRecieved(DialogueTrigger trigger, DialogueTextContainers dialogue)
    {
        dialogueTrigger = trigger;
        dialogueContainer = dialogue;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && firstLineWritten)
        {
            if (dialogueTrigger.GetCurrentTextLine() < dialogueContainer.dialogue.Length)
            {
                /*
                dialogueText.text = dialogueContainer.dialogue[dialogueTrigger.GetCurrentTextLine()];
                dialogueTrigger.IncreaseTextLine();
                */

                WriteDialogue(dialogueTrigger.GetCurrentTextLine());
            }
            else
            {
                RestartText();
                dialogueContainer = null;
                dialogueTrigger.DeactivateDialogueBox();
            }
        }
        else if (!firstLineWritten)
        {
            WriteDialogue(dialogueTrigger.GetCurrentTextLine());
            firstLineWritten = true;
        }
    }

    private void WriteDialogue(int index)
    {
        dialogueText.text = dialogueContainer.dialogue[index];
        dialogueTrigger.IncreaseTextLine();
    }
}