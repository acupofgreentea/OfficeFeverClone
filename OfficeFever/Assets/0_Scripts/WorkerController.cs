using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerController : MonoBehaviour
{
    private Animator anim;

    private WorkingDeskController workDesk;

    private readonly int isWorking = Animator.StringToHash("isWorking");

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        workDesk = GetComponentInParent<WorkingDeskController>();
    }

    private void Update()
    {
        if(workDesk.Papers.Count > 0)
            anim.SetBool(isWorking, true);
        else
            anim.SetBool(isWorking, false);
    }       
}
