using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour
{
    //Keeps track of each shields health and when a shield has no health it is destroyed.
    public ManagerOfGame Manager;
    public GameObject Shield;
    public int Health = 3;
    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Pellet")
        {
            Health = Health - 1;
            Destroy(collision.gameObject);
        }

        if (Health <= 0)
        {
            Destroy(Shield);
            Manager.AmountOfShields();
        }
    }
}
