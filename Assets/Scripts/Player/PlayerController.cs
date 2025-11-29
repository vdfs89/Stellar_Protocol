using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f; // Velocidade da nave
    public float tiltAmount = 30f; // Inclinação máxima
    public float tiltSmooth = 10f; // Suavização da rotação
    public float minX = -8f; // Limite esquerdo da tela
    public float maxX = 8f;  // Limite direito da tela

    [Header("Combat")]
    public GameObject bulletPrefab; // Prefab do tiro
    public Transform firePoint; // Ponto de disparo
    public float fireRate = 0.5f; // Tempo entre disparos

    private float moveX = 0f;
    private float currentTilt = 0f;
    private float nextFireTime = 0f;

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        // Detecta movimento lateral
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                moveX = -1;
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                moveX = 1;
            else
                moveX = 0;
        }

        // Movimento lateral baseado em eixo global
        Vector3 newPosition = transform.position + Vector3.right * moveX * speed * Time.deltaTime;

        // Aplica limites de tela
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;

        // Inclinação visual apenas (eixo Z)
        float targetTilt = -moveX * tiltAmount;
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSmooth);
        transform.rotation = Quaternion.Euler(0f, 0f, currentTilt);
    }

    void HandleShooting()
    {
        // Disparo com espaço
        if (Keyboard.current != null && Keyboard.current.spaceKey.isPressed && Time.time >= nextFireTime)
        {
            if (bulletPrefab != null && firePoint != null)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                nextFireTime = Time.time + fireRate;
            }
        }
    }
}
