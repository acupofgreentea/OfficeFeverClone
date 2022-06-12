using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorkingDeskController : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform moneyPrefab;

    [SerializeField] private Transform spawnPos;

    [SerializeField] private Transform papersPos;

    [SerializeField] private float spawnRate = 0.5f;

    private PlayerController playerController;

    private int stackCount = 10;

    private List<Transform> moneys = new List<Transform>();

    private List<Transform> papers = new List<Transform>();

    private void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();    
    }

    private void Start() 
    {
        InvokeRepeating(nameof(SpawnMoney), 0.0f, spawnRate);
    }

    public void Interact()
    {
        if(papers.Count >= 30) return;

        if(playerController.papers.Count == 0) return;

        var playerTopPaper = playerController.papers[playerController.papers.Count - 1];

        playerController.papers.Remove(playerTopPaper);

        playerTopPaper.parent = papersPos;

        var paperPos = new Vector3
        (papersPos.localPosition.x,
         papersPos.localPosition.y + (papers.Count / 20f),
         papersPos.localPosition.z);


        var paperRot = papersPos.rotation;

        papers.Add(playerTopPaper);

        playerTopPaper.DOLocalMove(paperPos, 0.3f);

        playerTopPaper.rotation = paperRot;
    }

    private void SpawnMoney()
    {
        if(moneys.Count >= 30) return;

        if(papers.Count == 0) return;

        var money = Instantiate(moneyPrefab);

        var rowCount = moneys.Count / stackCount;

        var spawnPosition = new Vector3(spawnPos.position.x + ((float)rowCount / 3), spawnPos.position.y + ((moneys.Count % stackCount) / 20f), spawnPos.position.z);

        moneys.Add(money);

        var topPaper = papers[papers.Count - 1];

        papers.Remove(topPaper);

        Destroy(topPaper.gameObject, 0.3f);

        money.transform.position = spawnPosition;
    }

    public void RemoveMoneyFromList(Transform money)
    {
        moneys.Remove(money);
    }
}
