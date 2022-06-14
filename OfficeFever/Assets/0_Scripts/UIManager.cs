using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerMoneySO playerMoney;

    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        UpdateMoneyText();
    }

    private void OnEnable()
    {
        playerMoney.OnMoneyCollected += UpdateMoneyText;
    }

    private void OnDisable()
    {
        playerMoney.OnMoneyCollected -= UpdateMoneyText;
    }

    public void UpdateMoneyText()
    {
        moneyText.text = $"${playerMoney.MoneyAmount}";
    }
}
