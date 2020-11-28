using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemsButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] PlayerState playerState;
    [SerializeField] private PopupManager popupManager;

    private bool isOpen = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleShowingItems();
    }

    private void ToggleShowingItems()
    {
        if (!isOpen)
        {
            if (popupManager.GetIsPopupOpen()) { return; }

            isOpen = true;
            popupManager.SetIsPopupOpen(true);
            playerState.OpenItems();
        }
        else
        {
            isOpen = false;
            popupManager.SetIsPopupOpen(false);
            playerState.CloseItems();
        }
    }
}
