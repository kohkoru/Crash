using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform player;
    private CharacterController characterController;
    private Transform currentCheckpoint;
    public Transform CurrentCheckpoint { set { currentCheckpoint = value; } }
    private void Awake()
    {
        currentCheckpoint = startPoint;
        characterController = player.GetComponent<CharacterController>();
    }
    public void MovePlayerToCheckPoint()
    {
        characterController.enabled = false;
        player.position = currentCheckpoint.position;
        characterController.enabled = true;
    }
}
