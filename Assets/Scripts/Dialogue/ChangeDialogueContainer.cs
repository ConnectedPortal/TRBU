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

    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchDialogueContainer();
            this.gameObject.SetActive(false);
        }
    }
}
