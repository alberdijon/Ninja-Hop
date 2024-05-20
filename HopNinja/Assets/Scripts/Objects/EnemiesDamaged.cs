using UnityEngine;

public class EnemiesDamages : MonoBehaviour
{
    public Animator animator;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma"))
        {
            animator.Play("HitAnimation");
            Destroy(transform.parent.gameObject);
        }
    }
}