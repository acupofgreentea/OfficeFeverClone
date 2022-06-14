using UnityEngine;
using TMPro;

public class BuyAreaController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buyAmountText;

    [SerializeField] private int buyAmount;

    [SerializeField] private GameObject deskToSpawn; 

    [SerializeField] private PlayerMoneySO playerMoney;

    private const string PLAYER_TAG = "Player";

    private float interactionTime = 0; 

    private float timeTobuy = 1.5f;

    private UIManager uiManager;

    private void Awake()
    {
        buyAmountText.text = $"${buyAmount}";

        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnCollisionStay(Collision other)
    {
        if (!other.gameObject.CompareTag(PLAYER_TAG)) return;

        interactionTime += Time.deltaTime;

        if(interactionTime >= timeTobuy)
        {
            if(playerMoney.MoneyAmount < buyAmount) return;

            var desk = Instantiate(deskToSpawn);

            desk.transform.position = transform.position;

            playerMoney.MoneyAmount -= buyAmount;

            uiManager.UpdateMoneyText();

            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        interactionTime = 0;
    }
}
