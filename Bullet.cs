using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage = 10f;
    public float Speed = 10f;
    public float Lifetime = 3f;

    void Start()
    {
        print("Bullet created");
        Invoke("DestroySelf", Lifetime);
    }

    void DestroySelf()
    {
        print("Bullet destroyed");
        Destroy(gameObject);
    }
}
