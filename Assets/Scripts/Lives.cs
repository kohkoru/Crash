using UnityEngine;
using UnityEngine.Events;

public class lives : MonoBehaviour
{
    [SerializeField]
    private int startingLives;
    [SerializeField]
    private UnityEvent onLoseLife;
    [SerializeField]
    private UnityEvent onDeath;
    [SerializeField]
    private UnityEvent startInvincibility;
    [SerializeField]
    private float InvincibilityLimit = 3;
    private int currentLives;
    private bool isDead => currentLives <= 0;
    public void initialize()
    {
        currentLives = startingLives;
    }
    public void Addlife(int amount)
    {
        if (currentLives == (InvincibilityLimit -1))
        {
            startInvincibility?.Invoke();
        }
        else
        {
            currentLives += amount;
        }
    }
    public void LoseLife()
    {
        currentLives--; 
        if (currentLives <= 0)
        {
            onDeath?.Invoke();
        }
        else
        {
            onLoseLife?.Invoke();
        }
    }
    public void Kill()
    {
        currentLives = 0;
        onDeath?.Invoke(); 
    }
}
