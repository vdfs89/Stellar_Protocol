using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Boss Settings")]
    public int health = 50;

    [Header("Attack Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float initialDelay = 2f;
    public float fireInterval = 1.5f;

    void Start()
    {
        InvokeRepeating(nameof(Fire), initialDelay, fireInterval);
    }

    void Fire()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        CancelInvoke(nameof(Fire));
        Destroy(gameObject);        
    }
}
