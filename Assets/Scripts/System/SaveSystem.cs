using UnityEngine;

/// <summary>
/// Sistema simples de salvamento usando PlayerPrefs.
/// </summary>
public class SaveSystem : MonoBehaviour
{
    private const string CoinsKey = "Coins";
    private const string LivesKey = "Lives";

    /// <summary>
    /// Grava moedas e vidas atuais nas preferências do jogador.
    /// </summary>
    public void Save()
    {
        PlayerPrefs.SetInt(CoinsKey, GameManager.Instance.coins);
        PlayerPrefs.SetInt(LivesKey, GameManager.Instance.lives);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Recupera moedas e vidas salvas, se existirem.
    /// </summary>
    public void Load()
    {
        if (PlayerPrefs.HasKey(CoinsKey))
            GameManager.Instance.coins = PlayerPrefs.GetInt(CoinsKey);
        if (PlayerPrefs.HasKey(LivesKey))
            GameManager.Instance.lives = PlayerPrefs.GetInt(LivesKey);
    }
}
