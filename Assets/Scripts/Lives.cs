using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class lives : MonoBehaviour
{
    [SerializeField]
    private int startingLives;
    [SerializeField]
    private UnityEvent<float> onLoseLife;
    [SerializeField]
    private UnityEvent onDeath;
    [SerializeField]
    private UnityEvent<float> startInvincibility;
    [SerializeField]
    private UnityEvent endInvincibility;
    [SerializeField]
    private float InvincibilityDuration = 2f;
    [SerializeField]
    private float fullInvincivilityDuration = 4f;
    private int invincibilitylimit = 3;
    private bool isInvincible;
    private bool isDead;
    public bool IsInvincible {set => isInvincible = value; }
    private int currentLives;
    public void initialize()
    {
        currentLives = startingLives;
        IsInvincible = false;
        isDead = false;
    }
    public void Addlife(int amount)
    {
        if (currentLives == (invincibilitylimit -1))
        {
            StartCoroutine(FullInvincivilityCoroutine());
        }
        else
        {
            currentLives += amount;
        }
    }
    public void LoseLife()
    {
        if (isInvincible || isDead) return;
        currentLives--;
        if (currentLives <= 0)
        {
            isDead = true;
            onDeath?.Invoke();
        }
        else
        {
            StartCoroutine(invincibilityCoroutine());
        }
    }
    private IEnumerator invincibilityCoroutine()
    {
        isDead = true;
        onLoseLife.Invoke(InvincibilityDuration);
        yield return new WaitForSeconds(InvincibilityDuration);
        isDead = false;
    }
    private IEnumerator FullInvincivilityCoroutine()
    {
        isInvincible = true;
        startInvincibility?.Invoke(fullInvincivilityDuration);
        yield return new WaitForSeconds(fullInvincivilityDuration);
        isInvincible = false;
        endInvincibility?.Invoke();
    }
    public void Kill()
    {
        isDead = true;
        currentLives = 0;
        onDeath?.Invoke(); 
    }
}
