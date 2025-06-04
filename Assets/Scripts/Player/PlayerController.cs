using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidade da nave
    public float tiltAmount = 30f; // Inclinação máxima
    public float tiltSmooth = 10f; // Suavização da rotação
    public GameObject bulletPrefab; // Prefab do tiro
    public Transform firePoint; // Ponto de disparo

    private float moveX = 0f;
    private float currentTilt = 0f;

    void Update()
    {
        // Detecta movimento lateral
        if (Keyboard.current.aKey.isPressed)
            moveX = -1;
        else if (Keyboard.current.dKey.isPressed)
            moveX = 1;
        else
            moveX = 0;

        // Movimento lateral baseado em eixo global (evita que incline o movimento)
        transform.position += Vector3.right * moveX * speed * Time.deltaTime;

        // Inclinação visual apenas (eixo Z)
        float targetTilt = -moveX * tiltAmount;
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSmooth);
        transform.rotation = Quaternion.Euler(0f, 0f, currentTilt);

        // Disparo com espaço
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
