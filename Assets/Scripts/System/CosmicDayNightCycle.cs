using UnityEngine;

/// <summary>
/// Altera gradualmente a cor do fundo simulando dia e noite.
/// </summary>
public class CosmicDayNightCycle : MonoBehaviour
{
    public Gradient colors;
    public float cycleDuration = 10f;
    private float timer = 0f;
    private Camera cam;

    /// <summary>
    /// Obtém referência para a câmera principal.
    /// </summary>
    void Start()
    {
        cam = Camera.main;
    }

    /// <summary>
    /// Atualiza a cor do fundo de acordo com o tempo.
    /// </summary>
    void Update()
    {
        if (cam == null) return;
        timer += Time.deltaTime;
        float t = Mathf.PingPong(timer / cycleDuration, 1f);
        cam.backgroundColor = colors.Evaluate(t);
    }
}
