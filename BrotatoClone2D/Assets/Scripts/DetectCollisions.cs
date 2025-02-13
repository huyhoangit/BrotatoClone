using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) return;

        if (this.gameObject.name == other.gameObject.name) return;

        // Prevent weapons from damaging the player
        if (this.gameObject.CompareTag("Weapon") && other.CompareTag("Player")) return;

        Debug.Log("Detected Collision: " + this.gameObject.name + ", " + other.gameObject.name);



        Character character = other.GetComponent<Character>();

        if (character != null) // If it's a player or enemy
        {
            character.TakeDamage(damageAmount);
        }

        if (this.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject); // Destroy the weapon
        }
    }
}
