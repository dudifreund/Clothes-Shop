using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasketButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] ShopManager shopManager;

    private bool isOpen = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleShowingShop();
    }

    private void ToggleShowingShop()
    {
        if (!isOpen)
        {
            isOpen = true;
            shopManager.OpenBasket();
        }
        else
        {
            isOpen = false;
            shopManager.CloseBasket();
        }
    }
}
