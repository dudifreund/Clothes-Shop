using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemsButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] PlayerState playerState;

    private bool isOpen = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleShowingItems();
    }

    private void ToggleShowingItems()
    {
        if (!isOpen)
        {
            isOpen = true;
            playerState.OpenItems();
        }
        else
        {
            isOpen = false;
            playerState.CloseItems();
        }
    }
}
