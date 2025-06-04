using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float velocidade = 5f;          // Velocidade com que a bala se move
    public float tempoDeVida = 5f;         // Tempo até a bala se autodestruir (caso não colida)
    
    void Start()
    {
        // Destroi a bala automaticamente após 'tempoDeVida' segundos
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        // Move a bala para frente na direção local "up"
        transform.Translate(Vector2.up * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se colidiu com o jogador
        if (other.CompareTag("Player"))
        {
            // Aqui você pode aplicar dano ou trigger de Game Over
            Destroy(gameObject); // Destroi a bala ao atingir o jogador
        }

        // Ignora colisões com inimigos e outras balas inimigas
        if (other.CompareTag("Inimigo") || other.CompareTag("EnemyBullet"))
        {
            return;
        }
    }

    void OnBecameInvisible()
    {
        // Destroi a bala automaticamente se ela sair da tela
        Destroy(gameObject);
    }
}
