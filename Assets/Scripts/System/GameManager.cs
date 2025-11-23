using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int coins = 0;
    public int lives = 3;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Moedas: " + coins);
        ProgressionManager.Instance?.AddScore(amount);
        AnalyticsManager.LogEvent("coin_collected");
    }

    public void TakeDamage()
    {
        lives--;
        AnalyticsManager.LogEvent("player_hit");
        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void Heal()
    {
        lives++;
        AnalyticsManager.LogEvent("player_healed");
    }
}