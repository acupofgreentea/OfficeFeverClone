using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Money", fileName = "Money")]
public class PlayerMoneySO : ScriptableObject
{
    [field: SerializeField] public int MoneyAmount {get; set;}

    public event Action OnMoneyCollected;

    public void UpdateMoneyAmout(int addToMoney)
    {
        MoneyAmount += addToMoney;
        OnMoneyCollected?.Invoke();
    }
}
