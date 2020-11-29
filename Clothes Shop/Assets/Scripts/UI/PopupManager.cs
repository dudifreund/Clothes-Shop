using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    private bool isPopupOpen = false;

    public bool GetIsPopupOpen()
    {
        return isPopupOpen;
    }

    public void SetIsPopupOpen(bool value)
    {
        isPopupOpen = value;
    }
}
