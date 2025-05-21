using UnityEngine;

public class Puha : MonoBehaviour
{
    Player _player;

    public Transform Target;
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;

    float _bulletSpeed = 10f;
    public float BulletSpread = .1f;
    public float FireRate = .2f;
    public float TimeFromLastShot = 0f;

    void Start()
    {
        _player = GetComponentInParent<Player>();

        _player.Controls.onFoot.piu.performed += ctx => Piu();

        _bulletSpeed = BulletPrefab.GetComponent<Bullet>().Speed;
    }

    void Update()
    {
        transform.LookAt(Target);
        TimeFromLastShot += Time.deltaTime;
    }

    protected virtual void Piu()
    {
        
    }

    protected void SpawnBullet()
    {
        if (TimeFromLastShot < FireRate) return;

        GameObject bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        
        Vector3 randomSpread = new Vector3(
            Random.Range(-BulletSpread, BulletSpread),
            Random.Range(-BulletSpread, BulletSpread),
            0
        );
        
        Vector3 spreadDirection = (BulletSpawnPoint.forward + randomSpread).normalized;
        bullet.GetComponent<Rigidbody>().linearVelocity = spreadDirection * _bulletSpeed;
    }
}
