using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionSystem : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Interactable currentInteractable = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentInteractable == null) { return; }

            if (currentInteractable.GetInteractionDirection() != movement.GetCurrentDirection()) { return; }

            currentInteractable.Interact();
        }
    }

    public void SetCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
    }

    public void ResetCurrentInteractable()
    {
        currentInteractable = null;
    }
}
