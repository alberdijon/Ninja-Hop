using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{

    public Text text;

    public string type;

    private string entryText;

    public string levelName;

    public bool inDoor = false;

    public int spr = 0;

    public int fg = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            entryText = text.text;
            text.text += type + ".";
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.text = entryText;
        text.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if (inDoor && Input.GetKey("e")) 
        { 
            
            SceneManager.LoadScene(levelName);

            PlayerPrefs.SetInt("SpR", spr);

            PlayerPrefs.SetFloat("Timer", 0f);

            PlayerPrefs.SetInt("fg", fg);

            PlayerPrefs.SetInt("sc", 0);

            PlayerPrefs.SetInt("FaseActual", 1);

        }
    }

    private void Start()
    {
        PlayerPrefs.SetInt("SpR", 0);
        PlayerPrefs.SetFloat("Timer", 0f);
        PlayerPrefs.SetInt("fg", 0);
        PlayerPrefs.SetInt("sc", 0);
    }

}
