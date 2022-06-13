using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PrinterController : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform paper;

    [SerializeField] private Transform spawnPos;

    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private int stackCount = 10;

    private PlayerController playerController;

    private List<Transform> papers = new List<Transform>();

    private void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    
    private void OnEnable() 
    {
        InvokeRepeating(nameof(SpawnPapers), 0.0f, spawnRate);
    }

    private void SpawnPapers()
    {
        if(papers.Count >= 30) return;

        var pap = Instantiate(paper);

        var rowCount = papers.Count / stackCount;

        var spawnPosition = new Vector3(spawnPos.position.x + ((float)rowCount / 3), spawnPos.position.y + ((papers.Count % stackCount) / 20f), spawnPos.position.z);

        papers.Add(pap);

        pap.transform.position = spawnPosition;
    }

    public void Interact()
    {
        if(papers.Count == 0) return;

        if(playerController.papers.Count >= 30) return;

        var topPaper = papers[papers.Count - 1];

        papers.Remove(topPaper);
        
        topPaper.parent = playerController.PaperHolder;

        var paperPos = new Vector3(playerController.PaperHolder.localPosition.x, playerController.PaperHolder.localPosition.y + (playerController.papers.Count / 20f), playerController.PaperHolder.localPosition.z);

        var paperRot = playerController.PaperHolder.rotation;
        
        playerController.papers.Add(topPaper);

        topPaper.DOLocalMove(paperPos, 0.3f);

        topPaper.rotation = paperRot;
    }
}
