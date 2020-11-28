using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField] DialogueTrigger dialogueTrigger;

    public override void Interact()
    {
        dialogueTrigger.TriggerDialogue();
    }
}