using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Removing direct HUD reference to decouple. 
    // PlayerStats can handle local player data or just delegate to GameManager.
    // For simplicity in this refactor, we'll make this script interact with GameManager.

    void Start()
    {
        // Initial sync if needed, but GameManager handles global state.
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet"))
        {
            GameManager.Instance.TakeDamage(1);
            // Optional: Destroy bullet if it's a bullet
            if (collision.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);
            }
        }

        if (collision.CompareTag("Star") || collision.CompareTag("Coin"))
        {
            GameManager.Instance.AddCoins(1);
            Destroy(collision.gameObject);
        }
    }
}
