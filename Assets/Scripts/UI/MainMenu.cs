using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Menu principal que inicia ou fecha o jogo.
/// </summary>

public class MainMenu : MonoBehaviour
{
    public string firstSceneName = "Game";

    /// <summary>
    /// Carrega a primeira cena do jogo.
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(firstSceneName);
    }

    /// <summary>
    /// Encerra a aplicação.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
