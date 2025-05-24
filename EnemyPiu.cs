using UnityEngine;

public class EnemyPiu : Bullet
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Hit player");
            other.gameObject.GetComponent<Health>().TakeDamage(1);

            Destroy(gameObject);
        }
    }
}
