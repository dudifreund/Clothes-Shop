using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;

    private void Awake()
    {
        FindObjectOfType<PlayerState>().OnMoneyUpdated += OnMoneyUpdatedHandler;
    }

    private void OnDestroy()
    {
        FindObjectOfType<PlayerState>().OnMoneyUpdated -= OnMoneyUpdatedHandler;
    }

    private void OnMoneyUpdatedHandler(int newMoney)
    {
        moneyText.text = newMoney.ToString();
    }
}
