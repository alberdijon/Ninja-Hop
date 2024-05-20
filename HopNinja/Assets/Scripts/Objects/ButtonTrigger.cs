using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject parentObject; 

    void Start()
    {

        if (parentObject == null)
        {
            parentObject = transform.parent.gameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Arma"))
        {
            Destroy(gameObject);
        }
    }

    
}