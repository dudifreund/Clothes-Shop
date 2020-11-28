using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text basketCountText;

    PlayerState playerState;
    ShopManager shopManager;

    private void Awake()
    {
        playerState = FindObjectOfType<PlayerState>();
        shopManager = FindObjectOfType<ShopManager>();

        playerState.OnMoneyUpdated += OnMoneyUpdatedHandler;
        shopManager.OnBasketUpdated += OnBasketUpdatedHandler;
    }

    private void OnDestroy()
    {
        playerState.OnMoneyUpdated -= OnMoneyUpdatedHandler;
        shopManager.OnBasketUpdated -= OnBasketUpdatedHandler;
    }

    private void OnMoneyUpdatedHandler(int newMoney)
    {
        moneyText.text = newMoney.ToString();
    }

    private void OnBasketUpdatedHandler(int newBasketCount)
    {
        basketCountText.text = newBasketCount.ToString();
    }
}
