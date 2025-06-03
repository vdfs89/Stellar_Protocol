using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        float moveX = 0;

        if (Keyboard.current.aKey.isPressed)
            moveX = -1;
        else if (Keyboard.current.dKey.isPressed)
            moveX = 1;

        transform.Translate(new Vector3(moveX, 0, 0) * speed * Time.deltaTime);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
