using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    //Timer that puts you back to the sample scene if all collectibles are not obtained in time.
    float countdown = 180.0f;
    public Text TimerText;
    public Text CollectibleText;
    public ManagerOfGame Manager;
    int CollectiblesNumber = 4;
    public GameObject Panel;
    public bool IsPanelActive = false;

    void Update()
    {
        if(countdown > 0 && IsPanelActive == false)
        {
            countdown = countdown - Time.deltaTime;
        }
        double Time2dp = System.Math.Round(countdown, 2);
        TimerText.text = Time2dp.ToString();
        CollectiblesNumber = Manager.Collectibles;
        CollectibleText.text = CollectiblesNumber.ToString();
        if(countdown < 30f)
        {
            TimerText.color = Color.red;
        }
        if(countdown <= 0)
        {
            Panel.SetActive(true);
        }
        
    }
}
