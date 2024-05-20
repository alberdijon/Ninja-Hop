using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public int newPhase = 3; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma"))
        {
            PlayerPrefs.SetInt("FaseActual", newPhase);
        }
    }
}