using UnityEngine;

public class PuhaAuto : Puha
{
    protected override void Piu()
    {
        base.Piu();
        if (TimeFromLastShot > FireRate)
        {
            SpawnBullet();
            Invoke("SpawnBullet", .1f);
            Invoke("SpawnBullet", .2f);
            Invoke("SpawnBullet", .3f);
            Invoke("ResetTimeFromLastShot", FireRate);
        }
    }

    void ResetTimeFromLastShot()
    {
        TimeFromLastShot = 0f;
    }

}
