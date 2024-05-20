using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSons : MonoBehaviour
{
    void Update()
    {
        bool childButtonsExist = false;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).name.StartsWith("Button"))
            {
                childButtonsExist = true;
                break;
            }
        }

        if (!childButtonsExist)
        {
            Destroy(gameObject);
        }
    }
}
