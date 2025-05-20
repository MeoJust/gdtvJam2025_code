using UnityEngine;

public class Puha : MonoBehaviour
{
    Player _player;

    [SerializeField] Transform _target;
    [SerializeField] Transform _bulletSpawnPoint;
    [SerializeField] GameObject _bulletPrefab;

    [SerializeField] float _bulletSpeed = 10f;
    [SerializeField] float _bulletSpread = .1f;

    void Start()
    {
        _player = GetComponentInParent<Player>();

        _player.Controls.onFoot.piu.performed += ctx => Piu();
    }

    void Update()
    {
        transform.LookAt(_target);
    }

    void Piu()
    {
        SpawnBullet();
    }

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        
        Vector3 randomSpread = new Vector3(
            Random.Range(-_bulletSpread, _bulletSpread),
            Random.Range(-_bulletSpread, _bulletSpread),
            0
        );
        
        Vector3 spreadDirection = (_bulletSpawnPoint.forward + randomSpread).normalized;
        bullet.GetComponent<Rigidbody>().linearVelocity = spreadDirection * _bulletSpeed;
    }
}
