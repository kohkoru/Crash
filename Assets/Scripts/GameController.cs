using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private CoinsController coinsController;
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Transform startPosition;
    private void start()
    {
        StartGame();
    }
    public void StartGame()
    {
        coinsController.Initialize();
        Player.position = startPosition.position;
    }
}
