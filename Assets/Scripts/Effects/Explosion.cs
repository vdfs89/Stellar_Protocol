using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Configurações")]
    public float duracao = 1f;         // Quanto tempo a explosão dura antes de desaparecer
    public AudioClip somExplosao;     // (Opcional) Som de explosão
    private AudioSource audioSource;

    void Start()
    {
        // Tenta tocar o som da explosão, se houver
        audioSource = GetComponent<AudioSource>();
        if (somExplosao != null && audioSource != null)
        {
            audioSource.PlayOneShot(somExplosao);
        }

        // Destroi este objeto após o tempo definido
        Destroy(gameObject, duracao);
    }
}
