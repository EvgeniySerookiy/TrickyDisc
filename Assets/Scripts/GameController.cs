using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private PlayerController _playerController;
    
    private void Awake()
    {
        _playerController.Initialize();
        _enemyManager.SpawnEnemy();
    }
}
