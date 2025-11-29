using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f; // Velocidade da nave
    public float dashSpeedMultiplier = 2f; // Multiplicador de velocidade ao dar dash
    public float tiltAmount = 30f; // Inclinação máxima
    public float tiltSmooth = 10f; // Suavização da rotação
    public float minX = -8f; // Limite esquerdo da tela
    public float maxX = 8f;  // Limite direito da tela
    public float minY = -4.5f; // Limite inferior da tela
    public float maxY = 4.5f;  // Limite superior da tela

    [Header("Combat")]
    public GameObject bulletPrefab; // Prefab do tiro
    public Transform firePoint; // Ponto de disparo
    public float fireRate = 0.2f; // Tempo entre disparos

    private float moveX = 0f;
    private float moveY = 0f;
    private float currentTilt = 0f;
    private float nextFireTime = 0f;

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float currentSpeed = speed;

        // Detecta input
        if (Keyboard.current != null)
        {
            // Horizontal
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                moveX = -1;
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                moveX = 1;
            else
                moveX = 0;

            // Vertical
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                moveY = 1;
            else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                moveY = -1;
            else
                moveY = 0;

            // Dash
            if (Keyboard.current.shiftKey.isPressed)
            {
                currentSpeed *= dashSpeedMultiplier;
            }
        }

        // Movimento vetorial (X e Y)
        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized;
        Vector3 newPosition = transform.position + movement * currentSpeed * Time.deltaTime;
        
        // Aplica limites de tela
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;

        // Inclinação visual apenas (eixo Z) - baseado no movimento X
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
