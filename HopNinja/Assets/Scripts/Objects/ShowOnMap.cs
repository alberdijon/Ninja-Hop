using UnityEngine;

public class ShowOnMap : MonoBehaviour
{

    public GameObject toActive;

    private void Start()
    {
        toActive.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma"))
        {
            
            toActive.SetActive(true);

        }
    }
}
