using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour/*, IPointerDownHandler*/
{
    private ShopManager shopManager;
    private ClothingItem clothingItem;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
    }

    public void AddItemToBasket()
    {
        shopManager.AddItemToBasket(clothingItem);
    }
    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        shopManager.AddItemToBasket(clothingItem);
    }
    */
    
    public void SetClothingItem(ClothingItem clothingItemToSet)
    {
        clothingItem = clothingItemToSet;
    }
}
