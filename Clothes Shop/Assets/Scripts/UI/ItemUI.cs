using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image imageComponent;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text nameText;

    public TMP_Text GetNameText()
    {
        return nameText;
    }
    
    public Image GetImageComponent()
    {
        return imageComponent;
    }

    public TMP_Text GetPriceText()
    {
        return priceText;
    }
}
