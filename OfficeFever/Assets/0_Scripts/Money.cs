using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerMoneySO playerMoney;

    [SerializeField] private int moneyAmount = 5;

    public void Interact()
    {
        playerMoney.UpdateMoneyAmout(moneyAmount);
        
        Destroy(gameObject);
    }
}
