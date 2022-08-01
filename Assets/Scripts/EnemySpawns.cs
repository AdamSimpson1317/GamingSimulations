using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{

    public GameObject Enemy1;
    public GameObject WalkableArea1;
    public GameObject WalkableArea2;
    public GameObject Enemy2;
    public GameObject WalkableArea3;
    public GameObject WalkableArea4;
    public GameObject Enemy3;
    public GameObject WalkableArea5;
    public GameObject WalkableArea6;
    public GameObject Enemy4;
    public GameObject WalkableArea7;
    public GameObject WalkableArea8;

    public NewTimer Timer;

    // Update is called once per frame
    void Update()
    {
        if (Timer.countdown < 150f)
        {
            WalkableArea1.SetActive(true);
            WalkableArea2.SetActive(true);
            Enemy1.SetActive(true);
        }
        if (Timer.countdown < 120f)
        {
            WalkableArea3.SetActive(true);
            WalkableArea4.SetActive(true);
            Enemy2.SetActive(true);
        }
        if (Timer.countdown < 90f)
        {
            WalkableArea5.SetActive(true);
            WalkableArea6.SetActive(true);
            Enemy3.SetActive(true);
        }
        if (Timer.countdown < 60f)
        {
            WalkableArea7.SetActive(true);
            WalkableArea8.SetActive(true);
            Enemy4.SetActive(true);
        }
    }
}
