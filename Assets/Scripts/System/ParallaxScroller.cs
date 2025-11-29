using UnityEngine;

/// <summary>
/// Cria efeito de parallax movendo múltiplos fundos a velocidades diferentes.
/// </summary>
public class ParallaxScroller : MonoBehaviour
{
    public Renderer[] backgrounds;
    public float[] speeds;

    /// <summary>
    /// Atualiza o deslocamento de cada camada para simular profundidade.
    /// </summary>
    void Update()
    {
        for (int i = 0; i < backgrounds.Length && i < speeds.Length; i++)
        {
            float offset = Time.time * speeds[i];
            backgrounds[i].material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
