using UnityEngine;
using UnityEngine.UI;

public class TutoExplication : MonoBehaviour
{
    public Text text;
    public string help;
    private float displayDuration = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            text.text = help;
            text.gameObject.SetActive(true);
            Invoke("HideText", displayDuration);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            text.text = help;
            text.gameObject.SetActive(true);
            displayDuration = 6f;
            Invoke("HideText", displayDuration);
        }
    }

    private void HideText()
    {
        text.gameObject.SetActive(false);
    }
}
