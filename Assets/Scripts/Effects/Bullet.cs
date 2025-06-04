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
        Destroy(gameObject); // Destroi a bala se sair da tela
    }
}
