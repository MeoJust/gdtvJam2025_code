using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHealth = 10;
    int _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        print(_currentHealth);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
