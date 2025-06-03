using UnityEngine;
using System.Collections.Generic;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager Instance;
    public int score = 0;
    public List<string> unlockedLevels = new List<string>();

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

    public void AddScore(int amount)
    {
        score += amount;
        AnalyticsManager.LogEvent("score_changed:" + score);
    }

    public void UnlockLevel(string levelName)
    {
        if (!unlockedLevels.Contains(levelName))
        {
            unlockedLevels.Add(levelName);
            AnalyticsManager.LogEvent("level_unlocked:" + levelName);
        }
    }
}
