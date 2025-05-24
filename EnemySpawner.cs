using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;

    [SerializeField] float _spawnRate = 3f;
    float _timeSinceLastEnemy = 0f;

    public int EnemyToSpawn = 10;
    int _currentEnemyCount = 0;

    bool _isAlreadySpawned = false;

    void Update()
    {
        if (_isAlreadySpawned) return;

        if (_currentEnemyCount <= EnemyToSpawn)
        {
            _timeSinceLastEnemy += Time.deltaTime;

            if (_timeSinceLastEnemy >= _spawnRate)
            {
                SpawnEnemy();
                _isAlreadySpawned = true;
                _timeSinceLastEnemy = 0f;
            }
        }
    }

    void SpawnEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        enemy.transform.parent = transform;
        enemy.OnEnemyDestroyed += OnEnemyDestroyed;
        _currentEnemyCount++;
    }

    void OnEnemyDestroyed()
    {
        EnemyToSpawn--;
        _isAlreadySpawned = false;
    }
}
