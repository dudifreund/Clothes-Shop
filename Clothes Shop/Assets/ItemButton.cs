using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private ShopManager shopManager;
    private ClothingItem clothingItem;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        shopManager.AddItemToBasket(clothingItem);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("You have unclicked the button " + name);
    }

    public void SetClothingItem(ClothingItem clothingItemToSet)
    {
        clothingItem = clothingItemToSet;
    }
}
