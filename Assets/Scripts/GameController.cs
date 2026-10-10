using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private CoinsController coinsController;
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private UnityEvent onGameStart;
    private void start()
    {
        StartGame();
    }

    public void StartGame()
    {
        coinsController.Initialize();
        Player.position = startPosition.position;
        onGameStart?.Invoke();
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
