using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTextWriter : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    public DialogueTextContainers dialogueContainer;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private void Start()
    {
        dialogueText.text = string.Empty;
    }

    public void MessageRecieved(DialogueTrigger trigger, DialogueTextContainers dialogue)
    {
        dialogueTrigger = trigger;
        dialogueContainer = dialogue;

        //StartCoroutine(DisplayDialogue(dialogue));
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueTrigger.DeactivateDialogueBox();
            dialogueContainer = null;
        }
    }
    
    /*
    private IEnumerator DisplayDialogue(DialogueTextContainers dialogue)
    {
        //int index = 0;

        //dialogueText.text = dialogue.dialogue.ToString();

        foreach (string text in dialogue.dialogue)
        {
            dialogueText.text += text.ToString();
        }
    }
    */
}