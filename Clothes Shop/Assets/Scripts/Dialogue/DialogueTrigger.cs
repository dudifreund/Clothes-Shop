using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        if(!dialogue.hasStarted)
        {
            dialogue.hasStarted = true;
            dialogueManager.StartDialogue(dialogue);
        }
        else
        {
            if (dialogueManager.DisplayNextSentence())
            {
                dialogue.hasStarted = false;
            }
        }
    }

    public void EndDialogue()
    {
        dialogue.hasStarted = false;
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
