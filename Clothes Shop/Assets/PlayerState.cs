using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int money = 100;

    public event Action<int> OnMoneyUpdated;

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
    }

    public void ShowPlayerItems()
    {
        if(playerItems.Count == 0)
        {
            Debug.Log("The player has no items");
            return;
        }

        Debug.Log("The Player has:");
        foreach (ClothingItem item in playerItems)
        {
            Debug.Log(" " + item.itemName);
        }
    }
}
