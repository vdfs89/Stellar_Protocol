using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;

    // Assets for programmatic UI generation if needed
    private Sprite heartSprite; // Would need to load these
    private Sprite starSprite;

    void Awake()
    {
        // If UI elements are not assigned, try to find them or create them
        if (scoreText == null || livesText == null)
        {
            CreateFallbackUI();
        }
    }

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCoinsChanged += UpdateScoreUI;
            GameManager.Instance.OnLivesChanged += UpdateLivesUI;

            // Initialize
            UpdateScoreUI(GameManager.Instance.coins);
            UpdateLivesUI(GameManager.Instance.lives);
        }
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCoinsChanged -= UpdateScoreUI;
            GameManager.Instance.OnLivesChanged -= UpdateLivesUI;
        }
    }

    void UpdateScoreUI(int coins)
    {
        if (scoreText != null)
            scoreText.text = "Coins: " + coins;
    }

    void UpdateLivesUI(int lives)
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    void CreateFallbackUI()
    {
        // Check if Canvas exists
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasGO = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            canvas = canvasGO.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        // Create Panel if not exists
        GameObject panelGO = new GameObject("HUDPanel", typeof(RectTransform), typeof(Image));
        panelGO.transform.SetParent(canvas.transform, false);
        RectTransform panelRT = panelGO.GetComponent<RectTransform>();
        panelRT.anchorMin = new Vector2(0, 1);
        panelRT.anchorMax = new Vector2(0, 1);
        panelRT.pivot = new Vector2(0, 1);
        panelRT.anchoredPosition = new Vector2(10, -10);
        panelRT.sizeDelta = new Vector2(300, 100);
        panelGO.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);

        // Create Lives Text
        if (livesText == null)
        {
            GameObject livesTextGO = new GameObject("LivesText", typeof(Text));
            livesTextGO.transform.SetParent(panelGO.transform, false);
            livesText = livesTextGO.GetComponent<Text>();
            livesText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            livesText.color = Color.white;
            livesText.alignment = TextAnchor.MiddleLeft;
            RectTransform ltRT = livesTextGO.GetComponent<RectTransform>();
            ltRT.anchoredPosition = new Vector2(10, -30);
            ltRT.sizeDelta = new Vector2(100, 30);
        }

        // Create Score Text
        if (scoreText == null)
        {
            GameObject scoreTextGO = new GameObject("ScoreText", typeof(Text));
            scoreTextGO.transform.SetParent(panelGO.transform, false);
            scoreText = scoreTextGO.GetComponent<Text>();
            scoreText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            scoreText.color = Color.white;
            scoreText.alignment = TextAnchor.MiddleLeft;
            RectTransform stRT = scoreTextGO.GetComponent<RectTransform>();
            stRT.anchoredPosition = new Vector2(120, -30);
            stRT.sizeDelta = new Vector2(150, 30);
        }
    }
}
