using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogueContainer", order = 1)]
public class DialogueTextContainers : ScriptableObject
{
    public string[] dialogue;
}