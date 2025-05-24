using UnityEngine;

public class EnemyPiu : Bullet
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Hit player");
        }
    }
}
