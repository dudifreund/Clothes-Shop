using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesCounter : Interactable
{
    [SerializeField] ShopTrigger shopTrigger;

    public override void Interact()
    {
        shopTrigger.ToggleShowingShop();
    }

    public override void EndInteraction()
    {
        shopTrigger.CloseShop();
    }
}
