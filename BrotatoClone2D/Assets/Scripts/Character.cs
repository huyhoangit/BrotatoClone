using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected int maxHealth = 100;
    protected int currentHealth;

    protected virtual void Start()
    {
        Debug.Log($"{gameObject.name}: Character.Start() called!");
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        Debug.Log("Health before being hit: " + currentHealth);
        currentHealth -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage! HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " died!");
        Destroy(gameObject);
    }
}
