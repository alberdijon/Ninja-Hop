using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && PlayerPrefs.GetInt("godMode") != 1)
        {
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}