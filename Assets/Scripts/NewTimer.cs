using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTimer : MonoBehaviour
{
    //Timer that puts you back to the overworld if you survive the timer
    public float countdown = 180.0f;
    public Text TimerText;
    public GameObject Panel;
    public bool IsPanelActive = false;

    void Update()
    {
        if (countdown > 0 && IsPanelActive == false)
        {
            countdown = countdown - Time.deltaTime;
        }
        double Time2dp = System.Math.Round(countdown, 2);
        TimerText.text = Time2dp.ToString();
        if (countdown < 30f)
        {
            TimerText.color = Color.green;
        }
        if (countdown <= 0)
        {
            Panel.SetActive(true);
        }

    }
}
