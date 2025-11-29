using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Utilitário para carregar e recarregar cenas.
/// </summary>

public class GameLoader : MonoBehaviour
{
    /// <summary>
    /// Carrega uma cena específica.
    /// </summary>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Recarrega a cena atual.
    /// </summary>
    public void ReloadCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
