using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogueContainer : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger;
    public DialogueTextContainers dialogueContainer;

    public void SwitchDialogueContainer()
    {
        Debug.Log("SWITCH DIALOGUE");
        dialogueTrigger.dialogueContainer = dialogueContainer;
        dialogueTrigger.hasMemory = true;
    }
}
