using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasketButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] ShopManager shopManager;
    [SerializeField] private PopupManager popupManager;

    private bool isOpen = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleShowingShop();
    }

    private void ToggleShowingShop()
    {
        if (!isOpen)
        {
            if (popupManager.GetIsPopupOpen()) { return; }

            isOpen = true;
            popupManager.SetIsPopupOpen(true);
            shopManager.OpenBasket();
        }
        else
        {
            isOpen = false;
            popupManager.SetIsPopupOpen(false);
            shopManager.CloseBasket();
        }
    }
}
