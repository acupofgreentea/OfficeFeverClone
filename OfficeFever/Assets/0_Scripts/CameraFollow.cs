using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    
    [SerializeField] private Transform player;

    [Range(0.1f, 1f)]
    [SerializeField] private float followSpeed;

    private Vector3 velocity = Vector3.zero;


    private void LateUpdate() 
    {
        var desiredPosition = player.position + offset;
        
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);
    }
}