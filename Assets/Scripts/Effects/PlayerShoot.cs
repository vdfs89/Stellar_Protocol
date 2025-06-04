using UnityEngine;
using UnityEngine.InputSystem; // Necessário para o novo sistema de input

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;     // Prefab da bala
    public Transform firePoint;         // Ponto de origem do disparo
    public float fireRate = 0.5f;       // Intervalo entre os tiros
    private float nextFireTime = 0f;

    public AudioClip tiroSom;           // Som do tiro
    private AudioSource audioSource;    // Fonte de som

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Pega o componente de som
    }

    void Update()
    {
        // Verifica se o espaço ou W foi pressionado e se já pode atirar novamente
        bool fireKey = 
            (Keyboard.current.spaceKey.isPressed || Keyboard.current.wKey.isPressed);

        if (fireKey && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Cria o projétil na posição e rotação do firePoint
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Reproduz o som do tiro (se houver)
        if (tiroSom != null && audioSource != null)
        {
            audioSource.PlayOneShot(tiroSom);
        }
    }
}
