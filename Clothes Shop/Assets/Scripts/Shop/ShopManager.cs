using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Animator shopAnimator;
    [SerializeField] private Animator basketAnimator;
    [SerializeField] Transform shopBoxContentTransform;
    [SerializeField] Transform basketBoxContentTransform;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject feedbackPopoup;
    [SerializeField] TMP_Text feedbackText;
    [SerializeField] TMP_Text basketTotalText;
    [SerializeField] private PlayerInteractionSystem playerInteractionSystem;
    [SerializeField] private Movement movement;
    [SerializeField] private PopupManager popupManager;
    
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

        ResetShopScrollPosition();

        ClearItemsInShop();

        PopulateItemsInShop(clothes);
    }

    private void ResetShopScrollPosition()
    {
        RectTransform shopRectTransform = (RectTransform)shopBoxContentTransform;
        shopRectTransform.offsetMin = new Vector2(shopRectTransform.offsetMin.x, 0f);
        shopRectTransform.offsetMax = new Vector2(shopRectTransform.offsetMax.x, 0f);
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

        ResetBasketScrollPosition();

        ClearItemsInBasket();

        PopulateItemsInBasket();

        basketTotalText.text = basketTotalPrice.ToString() + " $";
    }

    private void ResetBasketScrollPosition()
    {
        RectTransform basketRectTransform = (RectTransform)basketBoxContentTransform;
        basketRectTransform.offsetMin = new Vector2(basketRectTransform.offsetMin.x, 0f);
        basketRectTransform.offsetMax = new Vector2(basketRectTransform.offsetMax.x, 0f);
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
            Button button = instantiatedItem.GetComponent<Button>();
            Destroy(button);

            ItemUI itemUI = instantiatedItem.transform.GetComponent<ItemUI>();
            itemUI.GetImageComponent().sprite = item.itemIcon;
            itemUI.GetpriceText().text = item.itemPrice.ToString();
        }
    }

    public void CloseBasket()
    {
        basketAnimator.SetBool("isShown", false);
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
            feedbackPopoup.SetActive(true);
            popupManager.SetIsPopupOpen(true);
            feedbackText.text = "You have no items in your basket";
            return;
        }

        if (playerState.GetPlayerMoney() < basketTotalPrice)
        {
            feedbackPopoup.SetActive(true);
            popupManager.SetIsPopupOpen(true);
            feedbackText.text = "You don't have enough money";
            return;
        }

        playerState.AddPlayerMoney(-basketTotalPrice);

        feedbackPopoup.SetActive(true);
        popupManager.SetIsPopupOpen(true);
        feedbackText.text = "Successfully purchased!";
        
        foreach (ClothingItem item in basket)
        {
            playerState.AddItemToPlayerItems(item);
        }
        
        basket.Clear();
        OnBasketUpdated?.Invoke(basket.Count);
        basketTotalPrice = 0;
    }
}
