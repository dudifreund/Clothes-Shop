using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image imageComponent;
    [SerializeField] private TMP_Text priceText;

    public Image GetImageComponent()
    {
        return imageComponent;
    }

    public TMP_Text GetpriceText()
    {
        return priceText;
    }
}
