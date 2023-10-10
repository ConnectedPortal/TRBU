using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogueContainer : MonoBehaviour
{
    [Header("Input System")]
    private PlayerControls playerControls;

    [Header("Dialogue References")]
    [SerializeField] private DialogueTrigger dialogueTrigger;
    public DialogueTextContainers dialogueContainer;

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

    public void SwitchDialogueContainer()
    {
        Debug.Log("SWITCH DIALOGUE");
        dialogueTrigger.dialogueContainer = dialogueContainer;
        dialogueTrigger.hasMemory = true; //Make this option available in Editor
    }

    private void OnTriggerStay(Collider collider)
    {
        if (playerControls.Gameplay.Interaction.triggered)
        {
            SwitchDialogueContainer();
        }
    }
}
