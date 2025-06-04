using UnityEngine;

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
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Atira com ESPAÇO ou W
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Toca o som do tiro
        if (tiroSom != null && audioSource != null)
        {
            audioSource.PlayOneShot(tiroSom);
        }
    }
}