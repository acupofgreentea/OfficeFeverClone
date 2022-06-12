using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Money", fileName = "Money")]
public class PlayerMoneySO : ScriptableObject
{
    public int MoneyAmount {get; set;}

    public Action OnMoneyCollected;

    public void UpdateMoneyAmout(int addToMoney)
    {
        MoneyAmount += addToMoney;
        OnMoneyCollected?.Invoke();
    }
}
