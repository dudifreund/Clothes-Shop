using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Animator shopAnimator;
    [SerializeField] private Animator basketAnimator;
    [SerializeField] Transform shopBoxContentTransform;
    [SerializeField] Transform basketBoxContentTransform;
    [SerializeField] GameObject itemPrefab;

    public event Action<int> OnBasketUpdated;
    
    private PlayerState playerState;

    private List<ClothingItem> basket = new List<ClothingItem>();
    private int basketTotalPrice = 0;

    private void Start()
    {
        playerState = FindObjectOfType<PlayerState>();
    }
    
    public void OpenShop(ClothingItem[] clothes)
    {
        shopAnimator.SetBool("isShown", true);

        ClearItemsInShop();

        PopulateItemsInShop(clothes);
    }
    
    private void ClearItemsInShop()
    {
        foreach (Transform item in shopBoxContentTransform)
        {
            GameObject.Destroy(item.gameObject);
        }
    }

    private void PopulateItemsInShop(ClothingItem[] clothes)
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
        shopAnimator.SetBool("isShown", false);
    }

    public void OpenBasket()
    {
        basketAnimator.SetBool("isShown", true);

        ClearItemsInBasket();

        PopulateItemsInBasket();
    }

    private void ClearItemsInBasket()
    {
        foreach (Transform item in basketBoxContentTransform)
        {
            GameObject.Destroy(item.gameObject);
        }
    }

    private void PopulateItemsInBasket()
    {
        foreach (ClothingItem item in basket)
        {
            GameObject instantiatedItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            instantiatedItem.transform.SetParent(basketBoxContentTransform);
            ItemButton itemButton = instantiatedItem. GetComponent<ItemButton>();
            Destroy(itemButton);
            ItemUI itemUI = instantiatedItem.transform.GetComponent<ItemUI>();
            itemUI.GetImageComponent().sprite = item.itemIcon;
            itemUI.GetpriceText().text = item.itemPrice.ToString();
        }
    }

    public void CloseBasket()
    {
        basketAnimator.SetBool("isShown", false);

        //ClearItemsInBasket();

        //PopulateItemsInBasket(clothes);
    }
    
    public void AddItemToBasket(ClothingItem clothingItem)
    {
        basket.Add(clothingItem);
        basketTotalPrice += clothingItem.itemPrice;

        Debug.Log(clothingItem.itemName + " added to basket");
        Debug.Log("Total basket price is " + basketTotalPrice);
        OnBasketUpdated?.Invoke(basket.Count);
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
        OnBasketUpdated?.Invoke(basket.Count);
        basketTotalPrice = 0;
    }
}
