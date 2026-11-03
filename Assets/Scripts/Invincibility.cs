using System;
using UnityEngine;
using UnityEngine.Events;

public class Invincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration;
    [SerializeField]
    private float ghostDuration;
    private bool isInvincible;
    private bool isGhost;
    [SerializeField]
    private UnityEvent onInvincibilityStart;
    [SerializeField]
    private UnityEvent onInvincibilityEnd;
    private bool IsInvincible => isInvincible;
    private bool IsGhost => isGhost;
    private Blink playerBlink;
    private void Awake()
    {
        playerBlink = GetComponent<Blink>();
    }
    public void initialize()
    {
        isInvincible = false;
        isGhost = false;
    }
    public void Kill()
    {
        isGhost = true;
        isInvincible = true;
    }
    public void ActivateGhost()
    {
        playerBlink.StartBlink(ghostDuration);
        isGhost = true;
        Invoke(nameof(EndGhost), ghostDuration);
    }
    public void EndGhost()
    {
        isGhost = false;
    }
    public void ActivateInvincibility()
    {
        isInvincible = true;
        onInvincibilityStart?.Invoke();
        Invoke(nameof(EndInvincibility),  invincibilityDuration);
    }
    public void EndInvincibility()
    {
        isInvincible = false;
        onInvincibilityEnd?.Invoke();
    }
}
