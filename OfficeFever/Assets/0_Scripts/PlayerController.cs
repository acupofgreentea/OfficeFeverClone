using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Transform> papers = new List<Transform>();

    [field: SerializeField] public Transform PaperHolder {get; private set;}

}
