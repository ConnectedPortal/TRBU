using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTextWriter : MonoBehaviour
{
    [Header("Input System")]
    private PlayerControls playerControls;

    [Header("Text Writer")]
    private DialogueTrigger dialogueTrigger;
    public DialogueTextContainers dialogueContainer;
    [SerializeField] private TextMeshProUGUI dialogueText;
    public bool isDialogueFinished = false;
    private bool firstLineWritten = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        RestartText();
    }

    private void RestartText()
    {
        dialogueText.text = string.Empty;
        firstLineWritten = false;
    }

    public void MessageRecieved(DialogueTrigger trigger, DialogueTextContainers dialogue)
    {
        dialogueTrigger = trigger;
        dialogueContainer = dialogue;
    }
    
    private void Update()
    {
        if (playerControls.Gameplay.Interaction.triggered && firstLineWritten)
        {
            if (dialogueTrigger.GetCurrentTextLine() < dialogueContainer.dialogue.Length)
            {
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