using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterController : MonoBehaviour
{
    [SerializeField] private Transform paper;

    [SerializeField] private Transform spawnPos;
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private int stackCount = 10;

    private List<Transform> papers = new List<Transform>();
    

    private void Start() 
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
}
