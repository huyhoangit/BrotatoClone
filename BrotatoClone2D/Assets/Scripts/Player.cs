using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private int score = 0;
    private int coins = 0;
    public Text scoreText;
    public Text cointext;

    protected override void Start()
    {
        base.Start();
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    public void IncreaseCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
        UpdateCoinText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateCoinText()
    {
        if (cointext != null)
        {
            cointext.text = "Coins: " + coins;
        }
    }

    protected override void Die()
    {
        Debug.Log("Game Over! Player Died!");
        base.Die();
        //Time.timeScale = 0;
    }
}
