using UnityEngine;

public class BreakMap : MonoBehaviour
{

    public GameObject toBreak;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma"))
        {
            Destroy(toBreak, 0.5f);

        }
    }
}
