using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _aimSprite;
    [SerializeField] private SpriteRenderer _timeLimiter;

    public void EnableView()
    {
        _aimSprite.enabled = true;
        _timeLimiter.enabled = true;
    }
    
    public void DisableView()
    {
        _aimSprite.enabled = false;
        _timeLimiter.enabled = false;
    }
}
