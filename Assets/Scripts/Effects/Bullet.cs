using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocidade = 10f;

    void Update()
    {
        // Move na direção local "up" (para onde estiver rotacionada)
        transform.Translate(Vector2.up * velocidade * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        // Destroi a bala se sair da tela
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se colidiu com um inimigo
        if (other.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject); // Destroi o inimigo
            Destroy(gameObject);       // Destroi a bala
        }
    }
}
