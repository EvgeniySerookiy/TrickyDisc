using UnityEngine;
using Random = System.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _offsetX = 3.5f;
    [SerializeField] private float _offsetY = 0.5f;
    
    private Random _random = new ();

    public void SpawnEnemy()
    {
        var position = new Vector2(GetRandomSide(), _offsetY);
        var enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
        enemy.EnemyDead += OnEnemyDied;
        enemy.Initialize();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.EnemyDead -= OnEnemyDied;
        SpawnEnemy();
    }

    private float GetRandomSide()
    {
        float number1 = -_offsetX;
        float number2 = _offsetX;
        int numberRandom = _random.Next(2);
        return numberRandom == 0 ? number1 : number2;
    }
}
