using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
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
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
