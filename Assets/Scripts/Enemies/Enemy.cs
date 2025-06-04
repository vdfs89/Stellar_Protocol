using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;

    void OnDestroy()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}