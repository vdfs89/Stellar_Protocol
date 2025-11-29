using UnityEngine;

/// <summary>
/// Gera partículas de poeira estelar em intervalos regulares.
/// </summary>
public class StarDustSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnInterval = 2f;
    public Vector2 spawnArea = new Vector2(20f, 10f);

    private float timer = 0f;

    /// <summary>
    /// Controla o intervalo entre cada instância de poeira.
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }

    /// <summary>
    /// Instancia a partícula em uma posição aleatória.
    /// </summary>
    private void Spawn()
    {
        if (prefab == null) return;
        Vector3 pos = new Vector3(
            Random.Range(-spawnArea.x * 0.5f, spawnArea.x * 0.5f),
            Random.Range(-spawnArea.y * 0.5f, spawnArea.y * 0.5f),
            0f);
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
