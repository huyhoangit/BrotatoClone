using UnityEngine;

public class Player : Character
{
    protected override void Die()
    {
        Debug.Log("Game Over! Player Died!");
        // Add game-over logic here
        base.Die();
    }
}
