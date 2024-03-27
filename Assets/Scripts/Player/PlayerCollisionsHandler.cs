using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionsHandler : MonoBehaviour
{ 
    [SerializeField] public UnityEvent EnemyCollisionOccurred;
    [SerializeField] public UnityEvent PlayerCameStartPoint;
    
    public event Action DestroyedPlayer;
    public static event Action GameOver;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyCollisionOccurred?.Invoke();
        }
        
        if (other.CompareTag("Border"))
        {
            DestroyedPlayer?.Invoke();
            GameOver?.Invoke();
        }
        
        if (other.CompareTag("StartPointPlayer"))
        {
            PlayerCameStartPoint?.Invoke();
        }
    }
}