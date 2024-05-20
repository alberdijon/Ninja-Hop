using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Helps : MonoBehaviour
{
    public Image icon, map;
    public bool icAc, mapAc = false;

    private bool mapCollected = false;

    void Start()
    {
        icAc = PlayerPrefs.GetInt("godMode") == 1;
    }

    void Update()
    {
        if (mapCollected && Input.GetKeyDown(KeyCode.M) && SceneManager.GetActiveScene().name == "Map not working")
        {
{
            mapAc = !mapAc;
            map.gameObject.SetActive(mapAc);
        }
        }
        

            if (Input.GetKeyDown(KeyCode.I))
            {
                icAc = !icAc;
                icon.gameObject.SetActive(icAc);
                PlayerPrefs.SetInt("godMode", icAc ? 1 : 0);
            }


        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            mapCollected = true;

            collision.gameObject.SetActive(false);

        }
    }
}
