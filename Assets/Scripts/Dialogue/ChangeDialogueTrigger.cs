using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogueTrigger : MonoBehaviour
{
    [SerializeField] private ChangeDialogueContainer changeDialogueContainer;
    //private bool switchConditionsMet = false;

    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            changeDialogueContainer.SwitchDialogueContainer();
            this.gameObject.SetActive(false);
        }
    }
}
