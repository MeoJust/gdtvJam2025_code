using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    Player _player;

    [SerializeField] Transform _bulletSpawnPoint;
    [SerializeField] float _fireRate = 2f;
    [SerializeField] Bullet _enemyPiuPrefab;

    public Action OnEnemyDestroyed;

    void Start()
    {
        _player = FindObjectOfType<Player>();

        InvokeRepeating("Shoot", _fireRate, _fireRate);
    }

    void Update()
    {
        if (_player != null)
        {
            transform.LookAt(_player.transform);
        }
    }

    void Shoot()
    {
        var piu = Instantiate(_enemyPiuPrefab, _bulletSpawnPoint.position, Quaternion.identity);
        piu.transform.parent = transform;

        piu.transform.LookAt(_player.transform);
        piu.GetComponent<Rigidbody>().linearVelocity = piu.transform.forward * piu.Speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            print("Enemy destroyed");
            OnEnemyDestroyed?.Invoke();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
