using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private PopupManager popupManager;

    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        if (popupManager.GetIsPopupOpen()) { return; }

        if(!dialogueManager.hasStarted)
        {
            dialogueManager.StartDialogue(dialogue);
        }
        else
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    public void EndDialogue()
    {
        dialogueManager.EndDialogue();
    }
}
