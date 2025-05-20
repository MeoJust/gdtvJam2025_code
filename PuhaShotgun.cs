using UnityEngine;

public class PuhaShotgun : Puha
{
    protected override void Piu()
    {
        base.Piu();
        if (TimeFromLastShot > FireRate)
        {
            SpawnBullet();
            SpawnBullet();
            SpawnBullet();
            SpawnBullet();
            SpawnBullet();
            TimeFromLastShot = 0f;
        }
    }
}
