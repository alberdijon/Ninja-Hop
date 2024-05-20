using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossCtrl : MonoBehaviour
{
    public GameObject[] objectsToBreak1;
    public GameObject[] objectsToBreak2;
    public Vector3 phase2_3Position = new Vector3(-1.3f, -6.07f, 0f);

    void Start()
    {
        if (!PlayerPrefs.HasKey("FaseActual"))
        {
            PlayerPrefs.SetInt("FaseActual", 1);
        }

        int faseActual = PlayerPrefs.GetInt("FaseActual");

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level7.1")
        {
            if (faseActual >= 2)
            {
                transform.position = phase2_3Position;
            }
        }

        switch (faseActual)
        {
            case 1:
                break;
            case 2:
                RomperObjetos(objectsToBreak1);
                break;
            case 3:
                RomperObjetos(objectsToBreak2);
                break;
            default:
                Debug.LogError("FaseActual no válida: " + faseActual);
                break;
        }
    }

    void RomperObjetos(GameObject[] objetos)
    {
        foreach (GameObject objeto in objetos)
        {
            Destroy(objeto, 0.5f);
        }
    }
}