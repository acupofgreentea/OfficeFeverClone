using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private void OnTriggerStay(Collider other) 
    {
        if(other.GetComponent<IInteractable>() == null) return;

        var interactable = other.GetComponent<IInteractable>();

        interactable.Interact();
    }
}
