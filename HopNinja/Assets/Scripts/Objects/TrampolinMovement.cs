using UnityEngine;

public class TrampolinMovement : MonoBehaviour
{
    float jump = 5;
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerMove>().jump(jump);
            animator.Play("TrampolineAnimation");

        }
    }
}
