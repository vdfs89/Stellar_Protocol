using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Boss Settings")]
    public int health = 50;                         // Vida do chefe

    [Header("Movement Settings")]
    public float moveSpeed = 2f;                    // Velocidade do movimento horizontal
    public float leftLimit = -6f;                   // Limite esquerdo
    public float rightLimit = 6f;                   // Limite direito
    private int direction = 1;                      // Direção atual do movimento (1 = direita, -1 = esquerda)

    [Header("Attack Settings")]
    public GameObject bulletPrefab;                 // Prefab da bala inimiga
    public Transform[] firePoints;                  // Lista de pontos de tiro
    public float initialDelay = 2f;                 // Delay antes do primeiro tiro
    public float fireInterval = 1.5f;               // Intervalo entre os tiros
    private int fireIndex = 0;                      // Índice do ponto de tiro atual (vai alternando)

    void Start()
    {
        // Inicia o disparo automático com delay
        InvokeRepeating(nameof(Fire), initialDelay, fireInterval);
    }

    void Update()
    {
        // Move o chefe para a direita/esquerda constantemente
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        // Inverte a direção se atingir os limites
        if (transform.position.x >= rightLimit)
            direction = -1;
        else if (transform.position.x <= leftLimit)
            direction = 1;
    }

    void Fire()
    {
        // Verifica se há pontos de tiro e prefab válido
        if (bulletPrefab != null && firePoints.Length > 0)
        {
            // Frequência de tiro aumenta se a vida estiver baixa (Rage Mode)
            float currentInterval = health < 25 ? fireInterval / 2f : fireInterval;

            // Reagendar próximo tiro se necessário (a lógica original usa InvokeRepeating com tempo fixo,
            // então para alterar dinamicamente precisaríamos cancelar e invocar de novo, ou usar corotina.
            // Para simplicidade, vamos disparar múltiplos tiros em "Rage Mode" dentro deste método)

            int shotsToFire = health < 25 ? 3 : 1;

            for (int i = 0; i < shotsToFire; i++)
            {
                int index = (fireIndex + i) % firePoints.Length;
                Transform currentFirePoint = firePoints[index];
                Instantiate(bulletPrefab, currentFirePoint.position, currentFirePoint.rotation);
            }

            // Avança o índice
            fireIndex = (fireIndex + shotsToFire) % firePoints.Length;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        // Para de atirar e destrói o boss
        CancelInvoke(nameof(Fire));
        Destroy(gameObject);

        // Aqui você pode chamar efeitos visuais, som, pontuação, etc.
    }
}
