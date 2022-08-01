using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLost : MonoBehaviour
{
    public GameObject Player;
    public GameObject Panel;

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(Player);
            Panel.SetActive(true);
        }
    }
}
