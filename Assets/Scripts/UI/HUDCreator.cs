using UnityEngine;
using UnityEngine.UI;

public class HUDCreator : MonoBehaviour
{
    public Sprite heartSprite;
    public Sprite starSprite;

    private Text heartText;
    private Text starText;

    private int currentLives = 3;
    private int currentStars = 0;

    void Start()
    {
        // Canvas
        GameObject canvasGO = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        Canvas canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Painel
        GameObject panelGO = new GameObject("HUDPanel", typeof(RectTransform), typeof(Image));
        panelGO.transform.SetParent(canvasGO.transform, false);
        RectTransform panelRT = panelGO.GetComponent<RectTransform>();
        panelRT.anchorMin = new Vector2(0, 1);
        panelRT.anchorMax = new Vector2(0, 1);
        panelRT.pivot = new Vector2(0, 1);
        panelRT.anchoredPosition = new Vector2(10, -10);
        panelRT.sizeDelta = new Vector2(300, 100);
        panelGO.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);

        // Ícone coração
        GameObject heartGO = new GameObject("HeartIcon", typeof(Image));
        heartGO.transform.SetParent(panelGO.transform, false);
        Image heartImg = heartGO.GetComponent<Image>();
        heartImg.sprite = heartSprite;
        RectTransform heartRT = heartGO.GetComponent<RectTransform>();
        heartRT.anchoredPosition = new Vector2(30, -30);
        heartRT.sizeDelta = new Vector2(32, 32);

        // Texto vida
        GameObject heartTextGO = new GameObject("HeartText", typeof(Text));
        heartTextGO.transform.SetParent(panelGO.transform, false);
        heartText = heartTextGO.GetComponent<Text>();
        heartText.text = "x" + currentLives;
        heartText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        heartText.color = Color.white;
        RectTransform heartTextRT = heartTextGO.GetComponent<RectTransform>();
        heartTextRT.anchoredPosition = new Vector2(70, -30);
        heartTextRT.sizeDelta = new Vector2(100, 30);

        // Ícone estrela
        GameObject starGO = new GameObject("StarIcon", typeof(Image));
        starGO.transform.SetParent(panelGO.transform, false);
        Image starImg = starGO.GetComponent<Image>();
        starImg.sprite = starSprite;
        RectTransform starRT = starGO.GetComponent<RectTransform>();
        starRT.anchoredPosition = new Vector2(150, -30);
        starRT.sizeDelta = new Vector2(32, 32);

        // Texto estrelas
        GameObject starTextGO = new GameObject("StarText", typeof(Text));
        starTextGO.transform.SetParent(panelGO.transform, false);
        starText = starTextGO.GetComponent<Text>();
        starText.text = "x" + currentStars;
        starText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        starText.color = Color.white;
        RectTransform starTextRT = starTextGO.GetComponent<RectTransform>();
        starTextRT.anchoredPosition = new Vector2(190, -30);
        starTextRT.sizeDelta = new Vector2(100, 30);
    }

    // 👇 Chamado para reduzir vida
    public void UpdateLives(int newLives)
    {
        currentLives = Mathf.Max(newLives, 0);
        heartText.text = "x" + currentLives;
    }

    // 👇 Chamado para aumentar estrelas
    public void AddStar(int amount = 1)
    {
        currentStars += amount;
        starText.text = "x" + currentStars;
    }
}
