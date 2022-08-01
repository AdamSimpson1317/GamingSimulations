using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfPlayArea : MonoBehaviour
{
    public Vector3 StartPosition;
    public GameObject Player;
    public GameObject EmptyTextObject;
    // Update is called once per frame
    void Update()
    {
        //If Player goes 200 in any direction away from the start position then he will be asked to go back
        if (Player.transform.position.x > 200 || Player.transform.position.x < -200 || Player.transform.position.y > 200 || Player.transform.position.y < -200 || Player.transform.position.z > 200 || Player.transform.position.z < -200)
        {
            //Text Comes up on screen telling the player to go back
            EmptyTextObject.SetActive(true);
        }
        //If Player goes 400 in any direction away from the start position then he will be forcibly put back to the boss.
        else if (Player.transform.position.x > 400 || Player.transform.position.x < -400 || Player.transform.position.y > 400 || Player.transform.position.y < -400 || Player.transform.position.z > 400 || Player.transform.position.z < -400)
        {
            //Player is forcibly put back to area just above where boss can hit
            Player.transform.position = StartPosition;
        }
        else
        {
            //Makes sure text does not come up early and goes away when player is back in play area.
            EmptyTextObject.SetActive(false);
        }
    }
}
