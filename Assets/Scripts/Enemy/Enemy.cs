using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> EnemyDead;
    
    [SerializeField] private float _minMoveDuration;
    [SerializeField] private float _maxMoveDuration;
    [SerializeField] private float _delay;
    [SerializeField] private ParticleSystem _deathParticlePrefab;
    
    private float _minPointX;
    private float _maxPointX;
    private float _startTime;
    private Vector3 _startPosition;
    
    public void Initialize()
    {
        var sprite = GetComponent<SpriteRenderer>();
        var offset = sprite.bounds.size.x / 2;
        var camera = Camera.main;
        _minPointX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + offset;
        _maxPointX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - offset;
        Move();
    }
    

    private void Move()
    {
        var position = GetRandomPosition();
        var duration = GetRandomDuration();
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(position, duration));
        sequence.AppendInterval(_delay);
        sequence.OnComplete(Move);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(_deathParticlePrefab, transform.position, Quaternion.identity);
            EnemyDead?.Invoke(this);
            Destroy(gameObject);
        }
    }
    
    private float GetRandomDuration()
    {
        return Random.Range(_minMoveDuration, _maxMoveDuration);
    }

    private float GetRandomPosition()
    {
        return Random.Range(_minPointX, _maxPointX);
    }
    
}
