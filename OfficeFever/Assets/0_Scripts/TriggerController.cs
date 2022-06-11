using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private const string interactableTag = "Interactable";

    private void OnTriggerStay(Collider other) 
    {
        if(!other.CompareTag(interactableTag)) return;

        var interactable = other.GetComponent<IInteractable>();

        interactable.Interact();
    }
}
