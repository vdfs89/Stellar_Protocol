using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;

    void Update()
    {
        if (ProgressionManager.Instance != null && scoreText != null)
        {
            scoreText.text = "Score: " + ProgressionManager.Instance.score;
        }
        if (GameManager.Instance != null && livesText != null)
        {
            livesText.text = "Lives: " + GameManager.Instance.lives;
        }
    }
}
