using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerRotator _playerRotator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private PlayerTimeLimiter _playerTimeLimiter;
    [SerializeField] private PlayerCollisionsHandler _playerCollisionsHandler;
    [SerializeField] private ParticleSystem _deathParticlePlayer;
    
    private float _timer;

    public void Initialize()
    {
        _playerRotator.Initialize();
        _playerMovement.Initialize();
        
        _playerInput.MoveButtonPressed += OnMoveButtonPressed;
        _playerCollisionsHandler.PlayerCameStartPoint.AddListener(OnPlayerCameStartPoint);
        _playerCollisionsHandler.DestroyedPlayer += DestroyPlayer;
        _playerTimeLimiter.TimeIsOver += OnMoveButtonPressed;
        
        _playerTimeLimiter.StartTimer();
    }

    private void OnDestroy()
    {
        _playerInput.MoveButtonPressed -= OnMoveButtonPressed;
        _playerCollisionsHandler.PlayerCameStartPoint.RemoveAllListeners();
        _playerCollisionsHandler.DestroyedPlayer -= DestroyPlayer;
        _playerTimeLimiter.TimeIsOver -= OnMoveButtonPressed;
    }

    private void OnMoveButtonPressed()
    {
        AudioManager.Instance.PlayMoveSound();
        _playerTimeLimiter.StopTimer();
        _playerView.DisableView();
        _playerMovement.Move();
        _playerRotator.enabled = false;
    }

    private void OnPlayerCameStartPoint()
    {
        _playerView.EnableView();
        _playerTimeLimiter.StartTimer();
        _playerRotator.enabled = true;
        _playerMovement.StopMove();
    }
    
    private void DestroyPlayer()
    {
        AudioManager.Instance.PlayExplodeSound();
        Instantiate(_deathParticlePlayer, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
