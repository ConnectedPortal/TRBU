using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsRebinder : MonoBehaviour
{
    [SerializeField] private InputActionReference interaction;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private TMP_Text keyBindUI;

    private void Start()
    {
        //Make keybind text be whatever the control is
    }

    /// Return back to this with tutorial
    
    /*
    public void StartRebinding()
    {
        keyBindUI.text = "Awaiting Input...";

        interaction.action.PerformInteractiveRebinding().WithControlsExcluding("Mouse").OnMatchWaitForAnother(0.1f).OnComplete(operation => RebindFinish()).Start();
    }

    private void RebindFinish()
    {

    }
    */
}
