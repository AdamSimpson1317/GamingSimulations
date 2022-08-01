using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOribiter : MonoBehaviour
{
    //Makes the shields orbit the boss so that they move around the boss instead of being still.
    public GameObject Shield;
    public float speed;

    void Update()
    {
        Orbit();
    }

    void Orbit()
    {
        transform.RotateAround(Shield.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
