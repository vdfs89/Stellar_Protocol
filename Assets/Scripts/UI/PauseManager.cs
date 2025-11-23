using UnityEngine;

/// <summary>
/// Controla pausa e retomada do jogo.
/// </summary>
public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    private bool isPaused = false;

    /// <summary>
    /// Verifica a tecla de pausa a cada frame.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    /// <summary>
    /// Alterna entre estados de pausa e jogo.
    /// </summary>
    public void TogglePause()
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }

    /// <summary>
    /// Ativa a pausa.
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0f;
        if (pauseUI != null) pauseUI.SetActive(true);
        isPaused = true;
    }

    /// <summary>
    /// Retorna à execução normal do jogo.
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1f;
        if (pauseUI != null) pauseUI.SetActive(false);
        isPaused = false;
    }
}
