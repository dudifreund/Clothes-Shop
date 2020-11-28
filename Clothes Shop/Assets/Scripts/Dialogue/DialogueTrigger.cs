using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    public void TriggerDialogue()
    {
        if(!dialogue.hasStarted)
        {
            dialogue.hasStarted = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else
        {
            if (FindObjectOfType<DialogueManager>().DisplayNextSentence())
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
