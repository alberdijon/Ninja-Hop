using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FruitManager : MonoBehaviour
{

    public TextMeshProUGUI levelCleared;

    public Text timer;

    public GameObject transition;

    public bool added = false;

    public void Start()
    {
        added = false;
        int sp = PlayerPrefs.GetInt("SpR");

        if (sp == 1)
        {
            timer.GetComponent<Timer>().start();
            timer.gameObject.SetActive(true);
        }

    }

    private void Update()
    {
        AllFruitsCollected();
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {

            levelCleared.gameObject.SetActive(true);
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
        }
    }


    private void ChangeScene()
    {
        int sc = PlayerPrefs.GetInt("sc");
        if (!added)
        {
         sc += 1;
        PlayerPrefs.SetInt("sc", sc);
            added = true;
        }

        Debug.Log(sc);
        Debug.Log(PlayerPrefs.GetInt("fg"));

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        timer.GetComponent<Timer>().end();

        if (PlayerPrefs.GetInt("fg") == 0 && PlayerPrefs.GetInt("sc") >= 2)
        {
            SceneManager.LoadScene("Level0");
        }
        else
        {
            if (currentSceneIndex == totalScenes - 1)
            {
                PlayerPrefs.SetInt("godMode", 0);
                SceneManager.LoadScene("Level0");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }
}
