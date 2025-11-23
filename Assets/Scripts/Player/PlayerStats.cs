using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public HUDCreator hud;

    void Start()
    {
        hud.UpdateLives(3);
        hud.AddStar(0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            hud.UpdateLives(2);
        }

        if (collision.CompareTag("Star"))
        {
            hud.AddStar(1);
        }
    }
}
