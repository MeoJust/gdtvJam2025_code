using UnityEngine;

public class PuhaPistol : Puha
{
    protected override void Piu()
    {
        base.Piu();
        if (TimeFromLastShot > FireRate)
        {
            SpawnBullet();
            TimeFromLastShot = 0f;
        }
    }
}
