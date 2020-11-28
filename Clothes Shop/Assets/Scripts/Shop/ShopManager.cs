using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform shopBoxContentTransform;
    
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
            ItemUI itemUI = instantiatedItem.transform.GetComponent<ItemUI>();
            itemUI.GetImageComponent().sprite = item.itemIcon;
            itemUI.GetpriceText().text = item.itemPrice.ToString();
        }
    }

    public void CloseShop()
    {
        animator.SetBool("isShown", false);
    }
}
