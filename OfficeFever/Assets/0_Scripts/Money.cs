using UnityEngine;

public class Money : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerMoneySO playerMoney;

    [SerializeField] private int moneyAmount = 5;

    public void Interact()
    {
        playerMoney.UpdateMoneyAmout(moneyAmount);

        var parentDesk = GetComponentInParent<WorkingDeskController>();

        parentDesk.RemoveMoneyFromList(this.transform);
        
        Destroy(gameObject);
    }
}
