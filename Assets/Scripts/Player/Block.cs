using UnityEngine;

/// Este script deve ser colocado nos bloqueios laterais.
/// Ele impede que o jogador ultrapasse as bordas da tela,
/// usando colisão física (sem trigger).

public class PlayerBlocker : MonoBehaviour
{
    
    /// Detecta colisão com o jogador e impede que ele passe pelas laterais.
    /// O bloqueio funciona automaticamente se ambos os objetos tiverem colisor e Rigidbody2D.
    
    /// <param name="collision">Informações da colisão</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se quem colidiu foi o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
                        Debug.Log("Jogador encostou no bloqueio lateral");
        }
    }
}