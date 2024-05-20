using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string levelName;
    public bool isDoorToPhase2; 
    public int newPhase = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puerta"))
        {
            if(PlayerPrefs.GetInt("FaseActual") == 3 && SceneManager.GetActiveScene().name == "Level7.1")
            {
                levelName = "Level7.3";
            }

            SceneManager.LoadScene(levelName);

            if (isDoorToPhase2)
            {
                PlayerPrefs.SetInt("FaseActual", newPhase);
            }
        }
    }
}