using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int coins = 0;
    public int lives = 3;
    public int maxLives = 3;

    // Events for UI updates
    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize UI
        OnLivesChanged?.Invoke(lives);
        OnCoinsChanged?.Invoke(coins);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Moedas: " + coins);
        
        if (ProgressionManager.Instance != null)
            ProgressionManager.Instance.AddScore(amount);
            
        AnalyticsManager.LogEvent("coin_collected");
        OnCoinsChanged?.Invoke(coins);
    }

    public void TakeDamage(int damage = 1)
    {
        lives -= damage;
        AnalyticsManager.LogEvent("player_hit");
        
        OnLivesChanged?.Invoke(lives);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void Heal(int amount = 1)
    {
        lives = Mathf.Min(lives + amount, maxLives);
        AnalyticsManager.LogEvent("player_healed");
        OnLivesChanged?.Invoke(lives);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        // Implement Game Over logic here (e.g., reload scene, show UI)
    }
}
