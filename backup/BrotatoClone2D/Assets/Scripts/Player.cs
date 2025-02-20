using UnityEngine;

public class Player : Character
{
    protected override void Die()
    {
        Debug.Log("Game Over! Player Died!");
        base.Die();
        Time.timeScale = 0;
    }
}
