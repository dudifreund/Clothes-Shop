﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Vector2 interactionDirection;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteractionSystem>().SetCurrentInteractable(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteractionSystem>().ResetCurrentInteractable();
            EndInteraction();
        }
    }

    public Vector2 GetInteractionDirection()
    {
        return interactionDirection;
    }

    public virtual void Interact()
    {
        // Will be overridden
    }

    public virtual void EndInteraction()
    {
        // Will be overridden
    }
}
