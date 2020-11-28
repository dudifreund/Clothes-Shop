using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private ClothingItem[] clothes;
    
    private bool isOpen = false;
    
    public void ToggleShowingShop()
    {
        if (!isOpen)
        {
            OpenShop();
        }
        else
        {
            CloseShop();
        }
    }

    private void OpenShop()
    {
        isOpen = true;
        FindObjectOfType<ShopManager>().OpenShop(clothes);
    }

    public void CloseShop()
    {
        isOpen = false;
        FindObjectOfType<ShopManager>().CloseShop();
    }
}
