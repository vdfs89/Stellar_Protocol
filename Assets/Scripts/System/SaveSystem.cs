using UnityEngine;

/// <summary>
/// Sistema simples de salvamento usando SecurePlayerPrefs para proteção de dados.
/// </summary>
public class SaveSystem : MonoBehaviour
{
    private const string CoinsKey = "Coins";
    private const string LivesKey = "Lives";

    /// <summary>
    /// Grava moedas e vidas atuais nas preferências do jogador de forma criptografada.
    /// </summary>
    public void Save()
    {
        if (GameManager.Instance != null)
        {
            SecurePlayerPrefs.SetInt(CoinsKey, GameManager.Instance.coins);
            SecurePlayerPrefs.SetInt(LivesKey, GameManager.Instance.lives);
            SecurePlayerPrefs.Save();
            Debug.Log("Game Saved Securely.");
        }
    }

    /// <summary>
    /// Recupera moedas e vidas salvas, se existirem.
    /// </summary>
    public void Load()
    {
        if (GameManager.Instance != null)
        {
            if (SecurePlayerPrefs.HasKey(CoinsKey))
                GameManager.Instance.coins = SecurePlayerPrefs.GetInt(CoinsKey);

            if (SecurePlayerPrefs.HasKey(LivesKey))
                GameManager.Instance.lives = SecurePlayerPrefs.GetInt(LivesKey);

            Debug.Log("Game Loaded Securely.");
        }
    }
}
