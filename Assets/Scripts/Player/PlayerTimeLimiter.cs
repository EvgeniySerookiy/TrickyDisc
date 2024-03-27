using System;
using DG.Tweening;
using UnityEngine;

public class PlayerTimeLimiter : MonoBehaviour
{
    public event Action TimeIsOver;
    
    [SerializeField] private SpriteRenderer _timeLimiter;
    [SerializeField] private float _finalScale;
    [SerializeField] private float _timerDuration;
    
    private Tweener _scaleTween;
    
    public void StartTimer()
    {
        _scaleTween = _timeLimiter.transform
            .DOScale(new Vector3(_finalScale, _finalScale, _finalScale), _timerDuration)
            .OnComplete(() =>
            {
                TimeIsOver?.Invoke();
            });
    }

    public void StopTimer()
    {
        _scaleTween.Kill();
        _timeLimiter.transform.localScale = Vector3.one;
    }
}