using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private string shopTitle;
    [SerializeField] private ClothingItem[] clothes;
    [SerializeField] private PopupManager popupManager;
    
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
        if (popupManager.GetIsPopupOpen()) { return; }

        isOpen = true;
        popupManager.SetIsPopupOpen(true);
        FindObjectOfType<ShopManager>().OpenShop(clothes, shopTitle);
    }

    public void CloseShop()
    {
        isOpen = false;
        popupManager.SetIsPopupOpen(false);
        FindObjectOfType<ShopManager>().CloseShop();
    }
}
