using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform shopBoxContentTransform;
    
    private PlayerState playerState;

    private List<ClothingItem> basket = new List<ClothingItem>();
    private int basketTotalPrice = 0;

    private void Start()
    {
        playerState = FindObjectOfType<PlayerState>();
    }
    
    public void OpenShop(ClothingItem[] clothes)
    {
        animator.SetBool("isShown", true);

        ClearItems();

        PopulateItems(clothes);
    }

    private void ClearItems()
    {
        foreach (Transform item in shopBoxContentTransform)
        {
            GameObject.Destroy(item.gameObject);
        }
    }

    private void PopulateItems(ClothingItem[] clothes)
    {
        foreach (ClothingItem item in clothes)
        {
            GameObject instantiatedItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            instantiatedItem.transform.SetParent(shopBoxContentTransform);
            instantiatedItem.GetComponent<ItemButton>().SetClothingItem(item);
            ItemUI itemUI = instantiatedItem.transform.GetComponent<ItemUI>();
            itemUI.GetImageComponent().sprite = item.itemIcon;
            itemUI.GetpriceText().text = item.itemPrice.ToString();
        }
    }
    
    public void CloseShop()
    {
        animator.SetBool("isShown", false);
    }

    public void AddItemToBasket(ClothingItem clothingItem)
    {
        basket.Add(clothingItem);
        basketTotalPrice += clothingItem.itemPrice;

        Debug.Log(clothingItem.itemName + " added to basket");
        Debug.Log("Total basket price is " + basketTotalPrice);
    }

    public void TryToBuyItemsInBasket()
    {
        if (basket.Count == 0)
        {
            Debug.Log("You have no items in your basket");
            return;
        }

        if (playerState.GetPlayerMoney() < basketTotalPrice)
        {
            Debug.Log("You don't have enough money");
            return;
        }

        playerState.AddPlayerMoney(-basketTotalPrice);

        Debug.Log("You paid for your basket");

        foreach (ClothingItem item in basket)
        {
            playerState.AddItemToPlayerItems(item);
        }
        
        basket.Clear();
        basketTotalPrice = 0;
    }
}
