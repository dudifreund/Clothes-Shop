using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int money = 100;
    [SerializeField] private Animator itemsAnimator;
    [SerializeField] Transform itemsBoxContentTransform;
    [SerializeField] GameObject itemPrefab;

    public event Action<int> OnMoneyUpdated;
    public event Action<int> OnItemsUpdated;

    private List<ClothingItem> playerItems = new List<ClothingItem>();

    public int GetPlayerMoney()
    {
        return money;
    }

    public void AddPlayerMoney(int amountToAdd)
    {
        if (money + amountToAdd < 0) { return; }

        money += amountToAdd;
        OnMoneyUpdated?.Invoke(money);
    }

    public void AddItemToPlayerItems(ClothingItem item)
    {
        playerItems.Add(item);
        OnItemsUpdated?.Invoke(playerItems.Count);
    }
    
    public void OpenItems()
    {
        itemsAnimator.SetBool("isShown", true);

        ClearItemsInItems();

        PopulateItemsInItems();
    }

    private void ClearItemsInItems()
    {
        foreach (Transform item in itemsBoxContentTransform)
        {
            GameObject.Destroy(item.gameObject);
        }
    }

    private void PopulateItemsInItems()
    {
        foreach (ClothingItem item in playerItems)
        {
            GameObject instantiatedItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            instantiatedItem.transform.SetParent(itemsBoxContentTransform);
            ItemButton itemButton = instantiatedItem.GetComponent<ItemButton>();
            Destroy(itemButton);
            ItemUI itemUI = instantiatedItem.transform.GetComponent<ItemUI>();
            itemUI.GetImageComponent().sprite = item.itemIcon;
            itemUI.GetpriceText().text = "";
        }
    }

    public void CloseItems()
    {
        itemsAnimator.SetBool("isShown", false);
    }
}
