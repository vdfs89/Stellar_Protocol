using UnityEngine;

public class InimigoIA : MonoBehaviour
{
    public float velocidade = 2.5f;           // Velocidade de movimentação do inimigo
    public float distanciaMinima = 1f;        // Distância mínima para parar de seguir o jogador
    public GameObject balaInimigaPrefab;      // Prefab da bala que o inimigo vai disparar
    public Transform pontoDeTiro;             // Posição de onde a bala será instanciada
    public float intervaloTiro = 2f;          // Intervalo entre cada disparo

    private Transform jogador;                // Referência ao transform do jogador
    private float tempoProximoTiro;           // Controla o tempo do próximo tiro

    void Start()
    {
        // Encontra o jogador na cena usando a tag "Player"
        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        if (alvo != null)
            jogador = alvo.transform;

        // Define o tempo do primeiro tiro
        tempoProximoTiro = Time.time + intervaloTiro;
    }

    void Update()
    {
        if (jogador != null)
        {
            // Calcula a direção normalizada do inimigo em relação ao jogador
            Vector2 direcao = (jogador.position - transform.position).normalized;

            // Move o inimigo em direção ao jogador, se estiver longe o suficiente
            if (Vector2.Distance(jogador.position, transform.position) > distanciaMinima)
                transform.position += (Vector3)(direcao * velocidade * Time.deltaTime);

            // Rotaciona o inimigo para "olhar" na direção do jogador
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angulo);
        }

        // Se chegou a hora de atirar e os objetos estão atribuídos
        if (Time.time >= tempoProximoTiro && balaInimigaPrefab != null && pontoDeTiro != null)
        {
            // Instancia a bala inimiga na posição e rotação do ponto de tiro
            Instantiate(balaInimigaPrefab, pontoDeTiro.position, pontoDeTiro.rotation);

            // Atualiza o tempo do próximo tiro
            tempoProximoTiro = Time.time + intervaloTiro;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se colidir com uma bala do jogador
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destroi a bala
            Destroy(gameObject);       // Destroi o inimigo
        }

        // Se colidir diretamente com o jogador
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);       // Destroi o inimigo
            // Aqui você pode reduzir a vida do jogador ou chamar Game Over
        }
    }
}
