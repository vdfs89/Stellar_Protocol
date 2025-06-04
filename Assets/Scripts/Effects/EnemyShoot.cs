using UnityEngine;

public class BalaInimiga : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        // Move para frente na direção do inimigo (local up)
        transform.Translate(Vector2.up * velocidade * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // Auto-destruir se sair da tela
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aqui você pode reduzir a vida do jogador
            Destroy(gameObject);
        }
    }
}
