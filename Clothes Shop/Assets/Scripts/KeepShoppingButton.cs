using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeepShoppingButton : MonoBehaviour, IPointerDownHandler
{
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        dialogueManager.EndDialogue();
    }
}
