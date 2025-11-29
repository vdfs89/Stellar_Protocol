using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float velocidade = 2.5f;           // Velocidade de movimentação do inimigo
    public float distanciaMinima = 1f;        // Distância mínima para parar de seguir o jogador
    
    [Header("Combat")]
    public GameObject balaInimigaPrefab;      // Prefab da bala que o inimigo vai disparar
    public Transform pontoDeTiro;             // Posição de onde a bala será instanciada
    public float intervaloTiro = 2f;          // Intervalo entre cada disparo
    public int maxHealth = 1;                 // Vida do inimigo

    private Transform jogador;                // Referência ao transform do jogador
    private float tempoProximoTiro;           // Controla o tempo do próximo tiro
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        FindPlayer();
        
        // Define o tempo do primeiro tiro
        tempoProximoTiro = Time.time + intervaloTiro;
    }

    void FindPlayer()
    {
        if (jogador == null)
        {
            GameObject alvo = GameObject.FindGameObjectWithTag("Player");
            if (alvo != null)
                jogador = alvo.transform;
        }
    }

    void Update()
    {
        if (jogador == null)
        {
            FindPlayer(); // Try to find player again if lost reference (e.g. respawn) or if not found yet
        }

        if (jogador != null)
        {
            MoveTowardsPlayer();
            RotateTowardsPlayer();
        }

        HandleShooting();
    }

    void MoveTowardsPlayer()
    {
        // Calcula a direção normalizada do inimigo em relação ao jogador
        Vector2 direcao = (jogador.position - transform.position).normalized;
        float distancia = Vector2.Distance(jogador.position, transform.position);

        // Se estiver longe, move-se em direção ao jogador
        if (distancia > distanciaMinima)
        {
            // Adiciona um movimento senoidal lateral para "strafe"
            float strafe = Mathf.Sin(Time.time * 2f) * 0.5f;
            Vector2 movimento = direcao + new Vector2(strafe, 0); // Modifica ligeiramente a direção

            transform.position += (Vector3)(movimento.normalized * velocidade * Time.deltaTime);
        }
        else
        {
            // Se estiver perto, faz um movimento de órbita ou strafe lateral mais forte
            float strafe = Mathf.Sin(Time.time * 3f) * velocidade * Time.deltaTime;
            transform.position += transform.right * strafe;
        }
    }

    void RotateTowardsPlayer()
    {
        Vector2 direcao = (jogador.position - transform.position).normalized;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);
    }

    void HandleShooting()
    {
        // Se chegou a hora de atirar e os objetos estão atribuídos
        if (Time.time >= tempoProximoTiro && balaInimigaPrefab != null && pontoDeTiro != null)
        {
            // Instancia a bala inimiga na posição e rotação do ponto de tiro
            Instantiate(balaInimigaPrefab, pontoDeTiro.position, pontoDeTiro.rotation);

            // Atualiza o tempo do próximo tiro
            tempoProximoTiro = Time.time + intervaloTiro;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Trigger explosion if handled by another script (like Enemy.cs)
        Enemy enemyScript = GetComponent<Enemy>();
        if (enemyScript != null)
        {
            // Logic handled in OnDestroy of Enemy.cs, so just destroying is fine
        }
        
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se colidir com uma bala do jogador
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destroi a bala
            TakeDamage(1);
        }

        // Se colidir diretamente com o jogador
        if (other.CompareTag("Player"))
        {
            TakeDamage(100); // Instakill enemy on collision with player
            // Player damage is handled by PlayerStats
        }
    }
}
