using UnityEngine;

public class Destruction : MonoBehaviour
{
    [Tooltip("Tempo em segundos para autodestruição (0 = nunca destruir automaticamente)")]
    public float destroyAfterSeconds = 0f;

    [Tooltip("Destruir ao colidir com outro objeto?")]
    public bool destroyOnCollision = false;

    [Tooltip("Destruir ao entrar em trigger com outro objeto?")]
    public bool destroyOnTrigger = false;

    void Start()
    {
        if (destroyAfterSeconds > 0f)
        {
            Destroy(gameObject, destroyAfterSeconds);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyOnCollision)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (destroyOnTrigger)
        {
            Destroy(gameObject);
        }
    }
}
