using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyButton : MonoBehaviour, IPointerDownHandler
{
    private ShopManager shopManager;
    private DialogueManager dialogueManager;
    
    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        shopManager.TryToBuyItemsInBasket();
        dialogueManager.EndDialogue();
    }
}
