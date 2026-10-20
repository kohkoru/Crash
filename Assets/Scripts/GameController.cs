using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private UnityEvent onGameStart;
    [SerializeField]
    private UnityEvent onGameRestart;
    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        onGameStart?.Invoke();
    }
    public void RestartGame()
    {
        onGameRestart?.Invoke();
    }
}
