using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfGame : MonoBehaviour
{
    public int Shields = 5;
    public int Collectibles = 4;
    
    //Used to keep a track of how many shields and how many collectibles there are.
    public void AmountOfShields()
    {
        Shields = Shields - 1;
    }

    public void AmountOfCollectibles()
    {
        Collectibles = Collectibles - 1;
    }
}
