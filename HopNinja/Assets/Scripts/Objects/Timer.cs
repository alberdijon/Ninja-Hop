using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;

    public bool time = true;

    float timerValue;



    void Update()
    {
        if (time)
        {
            timerValue += Time.deltaTime;
            string formattedTimer = timerValue.ToString("F2");
            timer.text = formattedTimer;
            if (timer.text.Length > 5)
            {
                timer.text = timer.text.Substring(0, 5);
            }
        }
    }


    public void start()
    {        
        timerValue = PlayerPrefs.GetFloat("Timer");
        timer.text = timerValue.ToString();
        time = true;
    }

    public void end()
    {
        time = false;
        PlayerPrefs.SetFloat("Timer", timerValue);
    }
}
